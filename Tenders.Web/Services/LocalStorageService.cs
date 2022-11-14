﻿using System.Text.Json;
using ImagesViewerProject.Services.Interfaces;
using Microsoft.JSInterop;

namespace ImagesViewerProject.Services;

public class LocalStorageService : ILocalStorageService
{
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SetAsync<T>(string key, T item) where T : class
    {
        var data = JsonSerializer.Serialize(item);
        await _jsRuntime.InvokeVoidAsync("set", key, data);
    }   

    public Task SetStringAsync(string key, string value)
    {
        _jsRuntime.InvokeAsync<string>("set", key, value);
        return Task.CompletedTask;
    }

    public async Task<T> GetAsync<T>(string key) where T : class
    {
        var data = await _jsRuntime.InvokeAsync<string>("get", key);
        if (string.IsNullOrEmpty(data))
        {
            return null!;
        }

        return JsonSerializer.Deserialize<T>(data)!;
    }

    public async Task<string> GetStringAsync(string key)
    {
        return await _jsRuntime.InvokeAsync<string>("get", key);
    }

    public Task RemoveAsync(string key)
    {
        _jsRuntime.InvokeAsync<string>("remove", key);
        return Task.CompletedTask;
    }

    public async Task Log(string msg)
    {
        await _jsRuntime.InvokeAsync<string>("message", msg);
    }
}