<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "80e5c8949af5af0f401fce6f905990aa",
  "translation_date": "2025-07-17T00:44:57+00:00",
  "source_file": "08-BestPractices/README.md",
  "language_code": "pa"
}
-->
# MCP ਵਿਕਾਸ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸ

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ MCP ਸਰਵਰਾਂ ਅਤੇ ਫੀਚਰਾਂ ਨੂੰ ਉਤਪਾਦਨ ਵਾਤਾਵਰਣ ਵਿੱਚ ਵਿਕਸਿਤ, ਟੈਸਟ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਉੱਚ-ਸਤਹ ਦੇ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ 'ਤੇ ਧਿਆਨ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਜਿਵੇਂ ਜਿਵੇਂ MCP ਪਰਿਸਰ ਜਟਿਲਤਾ ਅਤੇ ਮਹੱਤਵ ਵਿੱਚ ਵੱਧਦੇ ਹਨ, ਸਥਾਪਿਤ ਪੈਟਰਨਾਂ ਦੀ ਪਾਲਣਾ ਕਰਨਾ ਭਰੋਸੇਯੋਗਤਾ, ਸੰਭਾਲਯੋਗਤਾ ਅਤੇ ਆਪਸੀ ਕੰਮਕਾਜ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ। ਇਹ ਪਾਠ ਅਸਲੀ ਦੁਨੀਆ ਦੇ MCP ਲਾਗੂ ਕਰਨ ਦੇ ਤਜਰਬਿਆਂ ਤੋਂ ਪ੍ਰਾਪਤ ਪ੍ਰਯੋਗਿਕ ਗਿਆਨ ਨੂੰ ਇਕੱਠਾ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ ਮਜ਼ਬੂਤ, ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਸਰਵਰ ਬਣਾਉਣ ਵਿੱਚ ਸਹਾਇਤਾ ਪ੍ਰਾਪਤ ਕਰ ਸਕੋ, ਜਿਨ੍ਹਾਂ ਵਿੱਚ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਸਰੋਤ, ਪ੍ਰਾਂਪਟ ਅਤੇ ਟੂਲ ਸ਼ਾਮਲ ਹਨ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:
- MCP ਸਰਵਰ ਅਤੇ ਫੀਚਰ ਡਿਜ਼ਾਈਨ ਵਿੱਚ ਉਦਯੋਗ ਦੇ ਸਰਵੋਤਮ ਅਭਿਆਸ ਲਾਗੂ ਕਰਨ
- MCP ਸਰਵਰਾਂ ਲਈ ਵਿਸਤ੍ਰਿਤ ਟੈਸਟਿੰਗ ਰਣਨੀਤੀਆਂ ਬਣਾਉਣ
- ਜਟਿਲ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਪ੍ਰਭਾਵਸ਼ਾਲੀ, ਦੁਬਾਰਾ ਵਰਤਣ ਯੋਗ ਵਰਕਫਲੋ ਪੈਟਰਨ ਡਿਜ਼ਾਈਨ ਕਰਨ
- MCP ਸਰਵਰਾਂ ਵਿੱਚ ਠੀਕ ਤਰ੍ਹਾਂ ਦੀ ਗਲਤੀ ਸੰਭਾਲ, ਲੌਗਿੰਗ ਅਤੇ ਨਿਰੀਖਣ ਲਾਗੂ ਕਰਨ
- ਪ੍ਰਦਰਸ਼ਨ, ਸੁਰੱਖਿਆ ਅਤੇ ਸੰਭਾਲਯੋਗਤਾ ਲਈ MCP ਲਾਗੂ ਕਰਨ ਦੀ ਅਪਟੀਮਾਈਜ਼ੇਸ਼ਨ

## MCP ਦੇ ਮੁੱਖ ਸਿਧਾਂਤ

ਖਾਸ ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਅਭਿਆਸਾਂ ਵਿੱਚ ਡੁੱਬਣ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ ਕਿ ਉਹ ਮੁੱਖ ਸਿਧਾਂਤ ਕਿਹੜੇ ਹਨ ਜੋ ਪ੍ਰਭਾਵਸ਼ਾਲੀ MCP ਵਿਕਾਸ ਨੂੰ ਮਾਰਗਦਰਸ਼ਨ ਕਰਦੇ ਹਨ:

1. **ਮਿਆਰੀਕ੍ਰਿਤ ਸੰਚਾਰ**: MCP ਆਪਣੀ ਬੁਨਿਆਦ ਵਜੋਂ JSON-RPC 2.0 ਵਰਤਦਾ ਹੈ, ਜੋ ਸਾਰੇ ਲਾਗੂ ਕਰਨ ਵਿੱਚ ਬੇਨਤੀ, ਜਵਾਬ ਅਤੇ ਗਲਤੀ ਸੰਭਾਲ ਲਈ ਇੱਕ ਸਥਿਰ ਫਾਰਮੈਟ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

2. **ਉਪਭੋਗਤਾ ਕੇਂਦਰਿਤ ਡਿਜ਼ਾਈਨ**: ਹਮੇਸ਼ਾ ਆਪਣੇ MCP ਲਾਗੂ ਕਰਨ ਵਿੱਚ ਉਪਭੋਗਤਾ ਦੀ ਸਹਿਮਤੀ, ਨਿਯੰਤਰਣ ਅਤੇ ਪਾਰਦਰਸ਼ਤਾ ਨੂੰ ਪਹਿਲ ਦਿਓ।

3. **ਸੁਰੱਖਿਆ ਪਹਿਲਾਂ**: ਮਜ਼ਬੂਤ ਸੁਰੱਖਿਆ ਉਪਾਅ ਲਾਗੂ ਕਰੋ, ਜਿਸ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕਤਾ, ਅਧਿਕਾਰ, ਵੈਧਤਾ ਜਾਂਚ ਅਤੇ ਦਰ ਸੀਮਾ ਸ਼ਾਮਲ ਹਨ।

4. **ਮਾਡਿਊਲਰ ਆਰਕੀਟੈਕਚਰ**: ਆਪਣੇ MCP ਸਰਵਰਾਂ ਨੂੰ ਮਾਡਿਊਲਰ ਢੰਗ ਨਾਲ ਡਿਜ਼ਾਈਨ ਕਰੋ, ਜਿੱਥੇ ਹਰ ਟੂਲ ਅਤੇ ਸਰੋਤ ਦਾ ਇੱਕ ਸਾਫ਼ ਅਤੇ ਕੇਂਦਰਿਤ ਉਦੇਸ਼ ਹੋਵੇ।

5. **ਸਟੇਟਫੁਲ ਕਨੈਕਸ਼ਨ**: MCP ਦੀ ਸਮਰੱਥਾ ਦਾ ਲਾਭ ਉਠਾਓ ਜੋ ਕਈ ਬੇਨਤੀਆਂ ਵਿੱਚ ਸਥਿਤੀ ਨੂੰ ਬਣਾਈ ਰੱਖਦਾ ਹੈ, ਤਾਂ ਜੋ ਵਧੇਰੇ ਸੰਗਠਿਤ ਅਤੇ ਸੰਦਰਭ-ਸੂਚਕ ਇੰਟਰੈਕਸ਼ਨ ਹੋ ਸਕਣ।

## ਅਧਿਕਾਰਕ MCP ਸਰਵੋਤਮ ਅਭਿਆਸ

ਹੇਠਾਂ ਦਿੱਤੇ ਸਰਵੋਤਮ ਅਭਿਆਸ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ ਦੀ ਅਧਿਕਾਰਕ ਦਸਤਾਵੇਜ਼ੀਕਰਨ ਤੋਂ ਲਏ ਗਏ ਹਨ:

### ਸੁਰੱਖਿਆ ਸਰਵੋਤਮ ਅਭਿਆਸ

1. **ਉਪਭੋਗਤਾ ਸਹਿਮਤੀ ਅਤੇ ਨਿਯੰਤਰਣ**: ਡਾਟਾ ਤੱਕ ਪਹੁੰਚ ਜਾਂ ਕਾਰਵਾਈ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ ਹਮੇਸ਼ਾ ਸਪਸ਼ਟ ਉਪਭੋਗਤਾ ਸਹਿਮਤੀ ਲੋੜੀਂਦੀ ਹੈ। ਇਹ ਸਪਸ਼ਟ ਨਿਯੰਤਰਣ ਦਿਓ ਕਿ ਕਿਹੜਾ ਡਾਟਾ ਸਾਂਝਾ ਕੀਤਾ ਜਾ ਰਿਹਾ ਹੈ ਅਤੇ ਕਿਹੜੀਆਂ ਕਾਰਵਾਈਆਂ ਮਨਜ਼ੂਰ ਹਨ।

2. **ਡਾਟਾ ਗੋਪਨੀਯਤਾ**: ਸਿਰਫ ਸਪਸ਼ਟ ਸਹਿਮਤੀ ਨਾਲ ਹੀ ਉਪਭੋਗਤਾ ਡਾਟਾ ਨੂੰ ਪ੍ਰਗਟ ਕਰੋ ਅਤੇ ਇਸ ਨੂੰ ਉਚਿਤ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਨਾਲ ਸੁਰੱਖਿਅਤ ਕਰੋ। ਬਿਨਾਂ ਅਧਿਕਾਰ ਦੇ ਡਾਟਾ ਪ੍ਰਸਾਰਣ ਤੋਂ ਬਚਾਓ।

3. **ਟੂਲ ਸੁਰੱਖਿਆ**: ਕਿਸੇ ਵੀ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ ਸਪਸ਼ਟ ਉਪਭੋਗਤਾ ਸਹਿਮਤੀ ਲੋੜੀਂਦੀ ਹੈ। ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਉਪਭੋਗਤਾ ਹਰ ਟੂਲ ਦੀ ਕਾਰਗੁਜ਼ਾਰੀ ਨੂੰ ਸਮਝਦੇ ਹਨ ਅਤੇ ਮਜ਼ਬੂਤ ਸੁਰੱਖਿਆ ਸੀਮਾਵਾਂ ਲਾਗੂ ਕਰੋ।

4. **ਟੂਲ ਅਧਿਕਾਰ ਨਿਯੰਤਰਣ**: ਸੈਸ਼ਨ ਦੌਰਾਨ ਮਾਡਲ ਨੂੰ ਕਿਹੜੇ ਟੂਲ ਵਰਤਣ ਦੀ ਆਗਿਆ ਹੈ, ਇਹ ਸੰਰਚਿਤ ਕਰੋ, ਤਾਂ ਜੋ ਸਿਰਫ ਸਪਸ਼ਟ ਤੌਰ 'ਤੇ ਮਨਜ਼ੂਰ ਟੂਲ ਹੀ ਉਪਲਬਧ ਹੋਣ।

5. **ਪ੍ਰਮਾਣਿਕਤਾ**: ਟੂਲਾਂ, ਸਰੋਤਾਂ ਜਾਂ ਸੰਵੇਦਨਸ਼ੀਲ ਕਾਰਵਾਈਆਂ ਤੱਕ ਪਹੁੰਚ ਦੇਣ ਤੋਂ ਪਹਿਲਾਂ ਠੀਕ ਪ੍ਰਮਾਣਿਕਤਾ ਲੋੜੀਂਦੀ ਹੈ, ਜਿਵੇਂ API ਕੁੰਜੀਆਂ, OAuth ਟੋਕਨ ਜਾਂ ਹੋਰ ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਤਰੀਕੇ।

6. **ਪੈਰਾਮੀਟਰ ਵੈਧਤਾ**: ਸਾਰੇ ਟੂਲ ਕਾਲਾਂ ਲਈ ਵੈਧਤਾ ਲਾਗੂ ਕਰੋ ਤਾਂ ਜੋ ਗਲਤ ਜਾਂ ਖ਼ਤਰਨਾਕ ਇਨਪੁੱਟ ਟੂਲ ਲਾਗੂ ਕਰਨ ਤੱਕ ਨਾ ਪਹੁੰਚੇ।

7. **ਦਰ ਸੀਮਾ**: ਸਰਵਰ ਸਰੋਤਾਂ ਦੇ ਦੁਰੁਪਯੋਗ ਨੂੰ ਰੋਕਣ ਅਤੇ ਨਿਆਂਸੰਗਤ ਵਰਤੋਂ ਯਕੀਨੀ ਬਣਾਉਣ ਲਈ ਦਰ ਸੀਮਾ ਲਾਗੂ ਕਰੋ।

### ਲਾਗੂ ਕਰਨ ਵਾਲੇ ਸਰਵੋਤਮ ਅਭਿਆਸ

1. **ਸਮਰੱਥਾ ਸਹਿਮਤੀ**: ਕਨੈਕਸ਼ਨ ਸੈਟਅਪ ਦੌਰਾਨ, ਸਮਰਥਿਤ ਫੀਚਰਾਂ, ਪ੍ਰੋਟੋਕੋਲ ਵਰਜਨਾਂ, ਉਪਲਬਧ ਟੂਲਾਂ ਅਤੇ ਸਰੋਤਾਂ ਬਾਰੇ ਜਾਣਕਾਰੀ ਦਾ ਅਦਾਨ-ਪ੍ਰਦਾਨ ਕਰੋ।

2. **ਟੂਲ ਡਿਜ਼ਾਈਨ**: ਕੇਂਦਰਿਤ ਟੂਲ ਬਣਾਓ ਜੋ ਇੱਕ ਕੰਮ ਨੂੰ ਚੰਗੀ ਤਰ੍ਹਾਂ ਕਰਦੇ ਹਨ, ਨਾ ਕਿ ਵੱਡੇ ਟੂਲ ਜੋ ਕਈ ਮੁੱਦਿਆਂ ਨੂੰ ਸੰਭਾਲਦੇ ਹਨ।

3. **ਗਲਤੀ ਸੰਭਾਲ**: ਮਿਆਰੀਕ੍ਰਿਤ ਗਲਤੀ ਸੁਨੇਹੇ ਅਤੇ ਕੋਡ ਲਾਗੂ ਕਰੋ ਜੋ ਸਮੱਸਿਆਵਾਂ ਦੀ ਪਛਾਣ ਕਰਨ, ਨੁਕਸਾਨਾਂ ਨੂੰ ਸੁਚੱਜੇ ਢੰਗ ਨਾਲ ਸੰਭਾਲਣ ਅਤੇ ਕਾਰਵਾਈਯੋਗ ਫੀਡਬੈਕ ਦੇਣ ਵਿੱਚ ਮਦਦ ਕਰਦੇ ਹਨ।

4. **ਲੌਗਿੰਗ**: ਪ੍ਰੋਟੋਕੋਲ ਇੰਟਰੈਕਸ਼ਨਾਂ ਦੀ ਆਡੀਟਿੰਗ, ਡੀਬੱਗਿੰਗ ਅਤੇ ਨਿਗਰਾਨੀ ਲਈ ਸੰਰਚਿਤ ਲੌਗਸ ਸੰਰਚਿਤ ਕਰੋ।

5. **ਪ੍ਰਗਤੀ ਟ੍ਰੈਕਿੰਗ**: ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੀਆਂ ਕਾਰਵਾਈਆਂ ਲਈ, ਪ੍ਰਗਤੀ ਅੱਪਡੇਟ ਦਿਓ ਤਾਂ ਜੋ ਜਵਾਬਦੇਹ ਉਪਭੋਗਤਾ ਇੰਟਰਫੇਸ ਬਣ ਸਕਣ।

6. **ਬੇਨਤੀ ਰੱਦ ਕਰਨਾ**: ਕਲਾਇੰਟਾਂ ਨੂੰ ਉਹ ਬੇਨਤੀਆਂ ਰੱਦ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿਓ ਜੋ ਹੁਣ ਲੋੜੀਂਦੀਆਂ ਨਹੀਂ ਹਨ ਜਾਂ ਜ਼ਿਆਦਾ ਸਮਾਂ ਲੈ ਰਹੀਆਂ ਹਨ।

## ਵਾਧੂ ਸੰਦਰਭ

MCP ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ ਬਾਰੇ ਸਭ ਤੋਂ ਨਵੀਂ ਜਾਣਕਾਰੀ ਲਈ, ਹੇਠਾਂ ਵੇਖੋ:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)
- [Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)

## ਪ੍ਰਯੋਗਿਕ ਲਾਗੂ ਕਰਨ ਦੇ ਉਦਾਹਰਨ

### ਟੂਲ ਡਿਜ਼ਾਈਨ ਸਰਵੋਤਮ ਅਭਿਆਸ

#### 1. ਇਕੱਲੀ ਜ਼ਿੰਮੇਵਾਰੀ ਦਾ ਸਿਧਾਂਤ

ਹਰ MCP ਟੂਲ ਦਾ ਇੱਕ ਸਾਫ਼ ਅਤੇ ਕੇਂਦਰਿਤ ਉਦੇਸ਼ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ। ਵੱਡੇ ਟੂਲ ਬਣਾਉਣ ਦੀ ਬਜਾਏ ਜੋ ਕਈ ਮੁੱਦਿਆਂ ਨੂੰ ਸੰਭਾਲਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਨ, ਵਿਸ਼ੇਸ਼ ਟੂਲ ਵਿਕਸਿਤ ਕਰੋ ਜੋ ਖਾਸ ਕੰਮਾਂ ਵਿੱਚ ਮਾਹਿਰ ਹੋਣ।

```csharp
// A focused tool that does one thing well
public class WeatherForecastTool : ITool
{
    private readonly IWeatherService _weatherService;
    
    public WeatherForecastTool(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    
    public string Name => "weatherForecast";
    public string Description => "Gets weather forecast for a specific location";
    
    public ToolDefinition GetDefinition()
    {
        return new ToolDefinition
        {
            Name = Name,
            Description = Description,
            Parameters = new Dictionary<string, ParameterDefinition>
            {
                ["location"] = new ParameterDefinition
                {
                    Type = ParameterType.String,
                    Description = "City or location name"
                },
                ["days"] = new ParameterDefinition
                {
                    Type = ParameterType.Integer,
                    Description = "Number of forecast days",
                    Default = 3
                }
            },
            Required = new[] { "location" }
        };
    }
    
    public async Task<ToolResponse> ExecuteAsync(IDictionary<string, object> parameters)
    {
        var location = parameters["location"].ToString();
        var days = parameters.ContainsKey("days") 
            ? Convert.ToInt32(parameters["days"]) 
            : 3;
            
        var forecast = await _weatherService.GetForecastAsync(location, days);
        
        return new ToolResponse
        {
            Content = new List<ContentItem>
            {
                new TextContent(JsonSerializer.Serialize(forecast))
            }
        };
    }
}
```

#### 2. ਲਗਾਤਾਰ ਗਲਤੀ ਸੰਭਾਲ

ਮਜ਼ਬੂਤ ਗਲਤੀ ਸੰਭਾਲ ਲਾਗੂ ਕਰੋ ਜਿਸ ਵਿੱਚ ਜਾਣਕਾਰੀ ਭਰਪੂਰ ਗਲਤੀ ਸੁਨੇਹੇ ਅਤੇ ਢੁਕਵੇਂ ਮੁੜ ਪ੍ਰਾਪਤੀ ਤਰੀਕੇ ਸ਼ਾਮਲ ਹਨ।

```python
# Python example with comprehensive error handling
class DataQueryTool:
    def get_name(self):
        return "dataQuery"
        
    def get_description(self):
        return "Queries data from specified database tables"
    
    async def execute(self, parameters):
        try:
            # Parameter validation
            if "query" not in parameters:
                raise ToolParameterError("Missing required parameter: query")
                
            query = parameters["query"]
            
            # Security validation
            if self._contains_unsafe_sql(query):
                raise ToolSecurityError("Query contains potentially unsafe SQL")
            
            try:
                # Database operation with timeout
                async with timeout(10):  # 10 second timeout
                    result = await self._database.execute_query(query)
                    
                return ToolResponse(
                    content=[TextContent(json.dumps(result))]
                )
            except asyncio.TimeoutError:
                raise ToolExecutionError("Database query timed out after 10 seconds")
            except DatabaseConnectionError as e:
                # Connection errors might be transient
                self._log_error("Database connection error", e)
                raise ToolExecutionError(f"Database connection error: {str(e)}")
            except DatabaseQueryError as e:
                # Query errors are likely client errors
                self._log_error("Database query error", e)
                raise ToolExecutionError(f"Invalid query: {str(e)}")
                
        except ToolError:
            # Let tool-specific errors pass through
            raise
        except Exception as e:
            # Catch-all for unexpected errors
            self._log_error("Unexpected error in DataQueryTool", e)
            raise ToolExecutionError(f"An unexpected error occurred: {str(e)}")
    
    def _contains_unsafe_sql(self, query):
        # Implementation of SQL injection detection
        pass
        
    def _log_error(self, message, error):
        # Implementation of error logging
        pass
```

#### 3. ਪੈਰਾਮੀਟਰ ਵੈਧਤਾ

ਹਮੇਸ਼ਾ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਪੂਰੀ ਤਰ੍ਹਾਂ ਜਾਂਚ ਕਰੋ ਤਾਂ ਜੋ ਗਲਤ ਜਾਂ ਖ਼ਤਰਨਾਕ ਇਨਪੁੱਟ ਨੂੰ ਰੋਕਿਆ ਜਾ ਸਕੇ।

```javascript
// JavaScript/TypeScript example with detailed parameter validation
class FileOperationTool {
  getName() {
    return "fileOperation";
  }
  
  getDescription() {
    return "Performs file operations like read, write, and delete";
  }
  
  getDefinition() {
    return {
      name: this.getName(),
      description: this.getDescription(),
      parameters: {
        operation: {
          type: "string",
          description: "Operation to perform",
          enum: ["read", "write", "delete"]
        },
        path: {
          type: "string",
          description: "File path (must be within allowed directories)"
        },
        content: {
          type: "string",
          description: "Content to write (only for write operation)",
          optional: true
        }
      },
      required: ["operation", "path"]
    };
  }
  
  async execute(parameters) {
    // 1. Validate parameter presence
    if (!parameters.operation) {
      throw new ToolError("Missing required parameter: operation");
    }
    
    if (!parameters.path) {
      throw new ToolError("Missing required parameter: path");
    }
    
    // 2. Validate parameter types
    if (typeof parameters.operation !== "string") {
      throw new ToolError("Parameter 'operation' must be a string");
    }
    
    if (typeof parameters.path !== "string") {
      throw new ToolError("Parameter 'path' must be a string");
    }
    
    // 3. Validate parameter values
    const validOperations = ["read", "write", "delete"];
    if (!validOperations.includes(parameters.operation)) {
      throw new ToolError(`Invalid operation. Must be one of: ${validOperations.join(", ")}`);
    }
    
    // 4. Validate content presence for write operation
    if (parameters.operation === "write" && !parameters.content) {
      throw new ToolError("Content parameter is required for write operation");
    }
    
    // 5. Path safety validation
    if (!this.isPathWithinAllowedDirectories(parameters.path)) {
      throw new ToolError("Access denied: path is outside of allowed directories");
    }
    
    // Implementation based on validated parameters
    // ...
  }
  
  isPathWithinAllowedDirectories(path) {
    // Implementation of path safety check
    // ...
  }
}
```

### ਸੁਰੱਖਿਆ ਲਾਗੂ ਕਰਨ ਦੇ ਉਦਾਹਰਨ

#### 1. ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ

```java
// Java example with authentication and authorization
public class SecureDataAccessTool implements Tool {
    private final AuthenticationService authService;
    private final AuthorizationService authzService;
    private final DataService dataService;
    
    // Dependency injection
    public SecureDataAccessTool(
            AuthenticationService authService,
            AuthorizationService authzService,
            DataService dataService) {
        this.authService = authService;
        this.authzService = authzService;
        this.dataService = dataService;
    }
    
    @Override
    public String getName() {
        return "secureDataAccess";
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        // 1. Extract authentication context
        String authToken = request.getContext().getAuthToken();
        
        // 2. Authenticate user
        UserIdentity user;
        try {
            user = authService.validateToken(authToken);
        } catch (AuthenticationException e) {
            return ToolResponse.error("Authentication failed: " + e.getMessage());
        }
        
        // 3. Check authorization for the specific operation
        String dataId = request.getParameters().get("dataId").getAsString();
        String operation = request.getParameters().get("operation").getAsString();
        
        boolean isAuthorized = authzService.isAuthorized(user, "data:" + dataId, operation);
        if (!isAuthorized) {
            return ToolResponse.error("Access denied: Insufficient permissions for this operation");
        }
        
        // 4. Proceed with authorized operation
        try {
            switch (operation) {
                case "read":
                    Object data = dataService.getData(dataId, user.getId());
                    return ToolResponse.success(data);
                case "update":
                    JsonNode newData = request.getParameters().get("newData");
                    dataService.updateData(dataId, newData, user.getId());
                    return ToolResponse.success("Data updated successfully");
                default:
                    return ToolResponse.error("Unsupported operation: " + operation);
            }
        } catch (Exception e) {
            return ToolResponse.error("Operation failed: " + e.getMessage());
        }
    }
}
```

#### 2. ਦਰ ਸੀਮਾ

```csharp
// C# rate limiting implementation
public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    private readonly ILogger<RateLimitingMiddleware> _logger;
    
    // Configuration options
    private readonly int _maxRequestsPerMinute;
    
    public RateLimitingMiddleware(
        RequestDelegate next,
        IMemoryCache cache,
        ILogger<RateLimitingMiddleware> logger,
        IConfiguration config)
    {
        _next = next;
        _cache = cache;
        _logger = logger;
        _maxRequestsPerMinute = config.GetValue<int>("RateLimit:MaxRequestsPerMinute", 60);
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        // 1. Get client identifier (API key or user ID)
        string clientId = GetClientIdentifier(context);
        
        // 2. Get rate limiting key for this minute
        string cacheKey = $"rate_limit:{clientId}:{DateTime.UtcNow:yyyyMMddHHmm}";
        
        // 3. Check current request count
        if (!_cache.TryGetValue(cacheKey, out int requestCount))
        {
            requestCount = 0;
        }
        
        // 4. Enforce rate limit
        if (requestCount >= _maxRequestsPerMinute)
        {
            _logger.LogWarning("Rate limit exceeded for client {ClientId}", clientId);
            
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.Headers.Add("Retry-After", "60");
            
            await context.Response.WriteAsJsonAsync(new
            {
                error = "Rate limit exceeded",
                message = "Too many requests. Please try again later.",
                retryAfterSeconds = 60
            });
            
            return;
        }
        
        // 5. Increment request count
        _cache.Set(cacheKey, requestCount + 1, TimeSpan.FromMinutes(2));
        
        // 6. Add rate limit headers
        context.Response.Headers.Add("X-RateLimit-Limit", _maxRequestsPerMinute.ToString());
        context.Response.Headers.Add("X-RateLimit-Remaining", (_maxRequestsPerMinute - requestCount - 1).ToString());
        
        // 7. Continue with the request
        await _next(context);
    }
    
    private string GetClientIdentifier(HttpContext context)
    {
        // Implementation to extract API key or user ID
        // ...
    }
}
```

## ਟੈਸਟਿੰਗ ਸਰਵੋਤਮ ਅਭਿਆਸ

### 1. MCP ਟੂਲਾਂ ਦੀ ਯੂਨਿਟ ਟੈਸਟਿੰਗ

ਹਮੇਸ਼ਾ ਆਪਣੇ ਟੂਲਾਂ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟ ਕਰੋ, ਬਾਹਰੀ ਨਿਰਭਰਤਾਵਾਂ ਨੂੰ ਮੌਕ ਕਰਕੇ:

```typescript
// TypeScript example of a tool unit test
describe('WeatherForecastTool', () => {
  let tool: WeatherForecastTool;
  let mockWeatherService: jest.Mocked<IWeatherService>;
  
  beforeEach(() => {
    // Create a mock weather service
    mockWeatherService = {
      getForecasts: jest.fn()
    } as any;
    
    // Create the tool with the mock dependency
    tool = new WeatherForecastTool(mockWeatherService);
  });
  
  it('should return weather forecast for a location', async () => {
    // Arrange
    const mockForecast = {
      location: 'Seattle',
      forecasts: [
        { date: '2025-07-16', temperature: 72, conditions: 'Sunny' },
        { date: '2025-07-17', temperature: 68, conditions: 'Partly Cloudy' },
        { date: '2025-07-18', temperature: 65, conditions: 'Rain' }
      ]
    };
    
    mockWeatherService.getForecasts.mockResolvedValue(mockForecast);
    
    // Act
    const response = await tool.execute({
      location: 'Seattle',
      days: 3
    });
    
    // Assert
    expect(mockWeatherService.getForecasts).toHaveBeenCalledWith('Seattle', 3);
    expect(response.content[0].text).toContain('Seattle');
    expect(response.content[0].text).toContain('Sunny');
  });
  
  it('should handle errors from the weather service', async () => {
    // Arrange
    mockWeatherService.getForecasts.mockRejectedValue(new Error('Service unavailable'));
    
    // Act & Assert
    await expect(tool.execute({
      location: 'Seattle',
      days: 3
    })).rejects.toThrow('Weather service error: Service unavailable');
  });
});
```

### 2. ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟਿੰਗ

ਕਲਾਇੰਟ ਦੀਆਂ ਬੇਨਤੀਆਂ ਤੋਂ ਲੈ ਕੇ ਸਰਵਰ ਦੇ ਜਵਾਬ ਤੱਕ ਪੂਰੇ ਪ੍ਰਕਿਰਿਆ ਨੂੰ ਟੈਸਟ ਕਰੋ:

```python
# Python integration test example
@pytest.mark.asyncio
async def test_mcp_server_integration():
    # Start a test server
    server = McpServer()
    server.register_tool(WeatherForecastTool(MockWeatherService()))
    await server.start(port=5000)
    
    try:
        # Create a client
        client = McpClient("http://localhost:5000")
        
        # Test tool discovery
        tools = await client.discover_tools()
        assert "weatherForecast" in [t.name for t in tools]
        
        # Test tool execution
        response = await client.execute_tool("weatherForecast", {
            "location": "Seattle",
            "days": 3
        })
        
        # Verify response
        assert response.status_code == 200
        assert "Seattle" in response.content[0].text
        assert len(json.loads(response.content[0].text)["forecasts"]) == 3
        
    finally:
        # Clean up
        await server.stop()
```

## ਪ੍ਰਦਰਸ਼ਨ ਅਪਟੀਮਾਈਜ਼ੇਸ਼ਨ

### 1. ਕੈਸ਼ਿੰਗ ਰਣਨੀਤੀਆਂ

ਲੇਟੈਂਸੀ ਅਤੇ ਸਰੋਤ ਖਪਤ ਘਟਾਉਣ ਲਈ ਉਚਿਤ ਕੈਸ਼ਿੰਗ ਲਾਗੂ ਕਰੋ:

```csharp
// C# example with caching
public class CachedWeatherTool : ITool
{
    private readonly IWeatherService _weatherService;
    private readonly IDistributedCache _cache;
    private readonly ILogger<CachedWeatherTool> _logger;
    
    public CachedWeatherTool(
        IWeatherService weatherService,
        IDistributedCache cache,
        ILogger<CachedWeatherTool> logger)
    {
        _weatherService = weatherService;
        _cache = cache;
        _logger = logger;
    }
    
    public string Name => "weatherForecast";
    
    public async Task<ToolResponse> ExecuteAsync(IDictionary<string, object> parameters)
    {
        var location = parameters["location"].ToString();
        var days = Convert.ToInt32(parameters.GetValueOrDefault("days", 3));
        
        // Create cache key
        string cacheKey = $"weather:{location}:{days}";
        
        // Try to get from cache
        string cachedForecast = await _cache.GetStringAsync(cacheKey);
        if (!string.IsNullOrEmpty(cachedForecast))
        {
            _logger.LogInformation("Cache hit for weather forecast: {Location}", location);
            return new ToolResponse
            {
                Content = new List<ContentItem>
                {
                    new TextContent(cachedForecast)
                }
            };
        }
        
        // Cache miss - get from service
        _logger.LogInformation("Cache miss for weather forecast: {Location}", location);
        var forecast = await _weatherService.GetForecastAsync(location, days);
        string forecastJson = JsonSerializer.Serialize(forecast);
        
        // Store in cache (weather forecasts valid for 1 hour)
        await _cache.SetStringAsync(
            cacheKey,
            forecastJson,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            });
        
        return new ToolResponse
        {
            Content = new List<ContentItem>
            {
                new TextContent(forecastJson)
            }
        };
    }
}

#### 2. Dependency Injection and Testability

Design tools to receive their dependencies through constructor injection, making them testable and configurable:

```java
// ਡਿਪੈਂਡੈਂਸੀ ਇੰਜੈਕਸ਼ਨ ਨਾਲ ਜਾਵਾ ਉਦਾਹਰਨ
public class CurrencyConversionTool implements Tool {
    private final ExchangeRateService exchangeService;
    private final CacheService cacheService;
    private final Logger logger;
    
    // ਕੰਸਟ੍ਰਕਟਰ ਰਾਹੀਂ ਨਿਰਭਰਤਾਵਾਂ ਇੰਜੈਕਟ ਕੀਤੀਆਂ ਗਈਆਂ
    public CurrencyConversionTool(
            ExchangeRateService exchangeService,
            CacheService cacheService,
            Logger logger) {
        this.exchangeService = exchangeService;
        this.cacheService = cacheService;
        this.logger = logger;
    }
    
    // ਟੂਲ ਲਾਗੂ ਕਰਨ ਦੀ ਵਿਧੀ
    // ...
}
```

#### 3. Composable Tools

Design tools that can be composed together to create more complex workflows:

```python
# ਪਾਇਥਨ ਉਦਾਹਰਨ ਜੋ ਜੋੜਨਯੋਗ ਟੂਲ ਦਿਖਾਉਂਦੀ ਹੈ
class DataFetchTool(Tool):
    def get_name(self):
        return "dataFetch"
    
    # ਲਾਗੂ ਕਰਨ...

class DataAnalysisTool(Tool):
    def get_name(self):
        return "dataAnalysis"
    
    # ਇਹ ਟੂਲ dataFetch ਟੂਲ ਦੇ ਨਤੀਜੇ ਵਰਤ ਸਕਦਾ ਹੈ
    async def execute_async(self, request):
        # ਲਾਗੂ ਕਰਨ...
        pass

class DataVisualizationTool(Tool):
    def get_name(self):
        return "dataVisualize"
    
    # ਇਹ ਟੂਲ dataAnalysis ਟੂਲ ਦੇ ਨਤੀਜੇ ਵਰਤ ਸਕਦਾ ਹੈ
    async def execute_async(self, request):
        # ਲਾਗੂ ਕਰਨ...
        pass

# ਇਹ ਟੂਲ ਸਵਤੰਤਰ ਤੌਰ 'ਤੇ ਜਾਂ ਵਰਕਫਲੋ ਦਾ ਹਿੱਸਾ ਵਜੋਂ ਵਰਤੇ ਜਾ ਸਕਦੇ ਹਨ
```

### Schema Design Best Practices

The schema is the contract between the model and your tool. Well-designed schemas lead to better tool usability.

#### 1. Clear Parameter Descriptions

Always include descriptive information for each parameter:

```csharp
public object GetSchema()
{
    return new {
        type = "object",
        properties = new {
            query = new { 
                type = "string", 
                description = "ਖੋਜ ਪੁੱਛਗਿੱਛ ਦਾ ਟੈਕਸਟ। ਵਧੀਆ ਨਤੀਜਿਆਂ ਲਈ ਸਹੀ ਕੀਵਰਡ ਵਰਤੋ।" 
            },
            filters = new {
                type = "object",
                description = "ਵਿਕਲਪਿਕ ਫਿਲਟਰ ਜੋ ਖੋਜ ਨਤੀਜਿਆਂ ਨੂੰ ਸੀਮਿਤ ਕਰਦੇ ਹਨ",
                properties = new {
                    dateRange = new { 
                        type = "string", 
                        description = "ਤਾਰੀਖ ਦੀ ਸੀਮਾ ਫਾਰਮੈਟ YYYY-MM-DD:YYYY-MM-DD" 
                    },
                    category = new { 
                        type = "string", 
                        description = "ਫਿਲਟਰ ਕਰਨ ਲਈ ਸ਼੍ਰੇਣੀ ਦਾ ਨਾਮ" 
                    }
                }
            },
            limit = new { 
                type = "integer", 
                description = "ਵਾਪਸ ਕਰਨ ਵਾਲੇ ਨਤੀਜਿਆਂ ਦੀ ਵੱਧ ਤੋਂ ਵੱਧ ਗਿਣਤੀ (1-50)",
                default = 10
            }
        },
        required = new[] { "query" }
    };
}
```

#### 2. Validation Constraints

Include validation constraints to prevent invalid inputs:

```java
Map<String, Object> getSchema() {
    Map<String, Object> schema = new HashMap<>();
    schema.put("type", "object");
    
    Map<String, Object> properties = new HashMap<>();
    
    // ਈਮੇਲ ਗੁਣਵੱਤਾ ਨਾਲ ਫਾਰਮੈਟ ਵੈਧਤਾ
    Map<String, Object> email = new HashMap<>();
    email.put("type", "string");
    email.put("format", "email");
    email.put("description", "ਉਪਭੋਗਤਾ ਦਾ ਈਮੇਲ ਪਤਾ");
    
    // ਉਮਰ ਗੁਣਵੱਤਾ ਨਾਲ ਨੰਬਰ ਸੰਬੰਧੀ ਸੀਮਾਵਾਂ
    Map<String, Object> age = new HashMap<>();
    age.put("type", "integer");
    age.put("minimum", 13);
    age.put("maximum", 120);
    age.put("description", "ਉਪਭੋਗਤਾ ਦੀ ਉਮਰ ਸਾਲਾਂ ਵਿੱਚ");
    
    // ਐਨਮਰੇਟਡ ਗੁਣਵੱਤਾ
    Map<String, Object> subscription = new HashMap<>();
    subscription.put("type", "string");
    subscription.put("enum", Arrays.asList("free", "basic", "premium"));
    subscription.put("default", "free");
    subscription.put("description", "ਸਬਸਕ੍ਰਿਪਸ਼ਨ ਦੀ ਪੱਧਰ");
    
    properties.put("email", email);
    properties.put("age", age);
    properties.put("subscription", subscription);
    
    schema.put("properties", properties);
    schema.put("required", Arrays.asList("email"));
    
    return schema;
}
```

#### 3. Consistent Return Structures

Maintain consistency in your response structures to make it easier for models to interpret results:

```python
async def execute_async(self, request):
    try:
        # ਬੇਨਤੀ ਪ੍ਰਕਿਰਿਆ
        results = await self._search_database(request.parameters["query"])
        
        # ਹਮੇਸ਼ਾ ਇੱਕ ਸਥਿਰ ਢਾਂਚਾ ਵਾਪਸ ਕਰੋ
        return ToolResponse(
            result={
                "matches": [self._format_item(item) for item in results],
                "totalCount": len(results),
                "queryTime": calculation_time_ms,
                "status": "success"
            }
        )
    except Exception as e:
        return ToolResponse(
            result={
                "matches": [],
                "totalCount": 0,
                "queryTime": 0,
                "status": "error",
                "error": str(e)
            }
        )
    
def _format_item(self, item):
    """ਹਰ ਆਈਟਮ ਲਈ ਇੱਕ ਸਥਿਰ ਢਾਂਚਾ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ"""
    return {
        "id": item.id,
        "title": item.title,
        "summary": item.summary[:100] + "..." if len(item.summary) > 100 else item.summary,
        "url": item.url,
        "relevance": item.score
    }
```

### Error Handling

Robust error handling is crucial for MCP tools to maintain reliability.

#### 1. Graceful Error Handling

Handle errors at appropriate levels and provide informative messages:

```csharp
public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
{
    try
    {
        string fileId = request.Parameters.GetProperty("fileId").GetString();
        
        try
        {
            var fileData = await _fileService.GetFileAsync(fileId);
            return new ToolResponse { 
                Result = JsonSerializer.SerializeToElement(fileData) 
            };
        }
        catch (FileNotFoundException)
        {
            throw new ToolExecutionException($"ਫਾਈਲ ਨਹੀਂ ਮਿਲੀ: {fileId}");
        }
        catch (UnauthorizedAccessException)
        {
            throw new ToolExecutionException("ਤੁਹਾਨੂੰ ਇਸ ਫਾਈਲ ਤੱਕ ਪਹੁੰਚ ਦਾ ਅਧਿਕਾਰ ਨਹੀਂ ਹੈ");
        }
        catch (Exception ex) when (ex is IOException || ex is TimeoutException)
        {
            _logger.LogError(ex, "ਫਾਈਲ {FileId} ਤੱਕ ਪਹੁੰਚ ਵਿੱਚ ਗਲਤੀ", fileId);
            throw new ToolExecutionException("

IMPORTANT RULES:
1. ਅਨੁਵਾਦ ਦੇ ਆਲੇ-ਦੁਆਲੇ '''markdown ਜਾਂ ਹੋਰ ਕਿਸੇ ਵੀ ਟੈਗ ਨੂੰ ਨਾ ਜੋੜੋ
2. ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਅਨੁਵਾਦ ਬਹੁਤ ਜ਼ਿਆਦਾ ਸ਼ਾਬਦਿਕ ਨਾ ਲੱਗੇ
3. ਟਿੱਪਣੀਆਂ ਦਾ ਵੀ ਅਨੁਵਾਦ ਕਰੋ
4. ਇਹ ਫਾਈਲ Markdown ਫਾਰਮੈਟ ਵਿੱਚ ਲਿਖੀ ਗਈ ਹੈ - ਇਸਨੂੰ XML ਜਾਂ HTML ਵਾਂਗ ਨਾ ਸਮਝੋ
5. ਅਨੁਵਾਦ ਨਾ ਕਰੋ:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ਵੈਰੀਏਬਲ ਨਾਮ, ਫੰਕਸ਼ਨ ਨਾਮ, ਕਲਾਸ ਨਾਮ
   - ਜਗ੍ਹਾ ਰੱਖਣ ਵਾਲੇ ਜਿਵੇਂ @@INLINE_CODE_x@@ ਜਾਂ @@CODE_BLOCK_x@@
   - URLs ਜਾਂ ਪਾਥ
6. ਸਾਰੇ ਮੂਲ Markdown ਫਾਰਮੈਟਿੰਗ ਨੂੰ ਬਰਕਰਾਰ ਰੱਖੋ
7. ਸਿਰਫ ਅਨੁਵਾਦਿਤ ਸਮੱਗਰੀ ਵਾਪਸ ਕਰੋ, ਕਿਸੇ ਹੋਰ ਟੈਗ ਜਾਂ ਮਾਰਕਅੱਪ ਦੇ ਬਿਨਾਂ
ਕਿਰਪਾ ਕਰਕੇ ਨਤੀਜਾ ਖੱਬੇ ਤੋਂ ਸੱਜੇ ਲਿਖੋ।

ExecuteAsync(ToolRequest request)
{
    var query = request.Parameters.GetProperty("query").GetString();
    
    // ਪੈਰਾਮੀਟਰਾਂ ਦੇ ਆਧਾਰ 'ਤੇ cache key ਬਣਾਓ
    var cacheKey = $"data_query_{ComputeHash(query)}";
    
    // ਪਹਿਲਾਂ cache ਵਿੱਚੋਂ ਲੱਭਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ
    if (_cache.TryGetValue(cacheKey, out var cachedResult))
    {
        return new ToolResponse { Result = cachedResult };
    }
    
    // Cache miss - ਅਸਲ ਕਵੈਰੀ ਕਰੋ
    var result = await _database.QueryAsync(query);
    
    // ਮਿਆਦ ਨਾਲ cache ਵਿੱਚ ਸਟੋਰ ਕਰੋ
    var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
        
    _cache.Set(cacheKey, JsonSerializer.SerializeToElement(result), cacheOptions);
    
    return new ToolResponse { Result = JsonSerializer.SerializeToElement(result) };
}

private string ComputeHash(string input)
{
    // cache key ਲਈ ਸਥਿਰ ਹੈਸ਼ ਬਣਾਉਣ ਦੀ ਕਾਰਜਵਾਈ
}
}
```

#### 2. Asynchronous Processing

Use asynchronous programming patterns for I/O-bound operations:

```java
public class AsyncDocumentProcessingTool implements Tool {
    private final DocumentService documentService;
    private final ExecutorService executorService;
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        String documentId = request.getParameters().get("documentId").asText();
        
        // ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਲਈ, ਤੁਰੰਤ ਇੱਕ ਪ੍ਰੋਸੈਸ ID ਵਾਪਸ ਕਰੋ
        String processId = UUID.randomUUID().toString();
        
        // Async ਪ੍ਰੋਸੈਸਿੰਗ ਸ਼ੁਰੂ ਕਰੋ
        CompletableFuture.runAsync(() -> {
            try {
                // ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲਾ ਕੰਮ ਕਰੋ
                documentService.processDocument(documentId);
                
                // ਸਥਿਤੀ ਅਪਡੇਟ ਕਰੋ (ਆਮ ਤੌਰ 'ਤੇ ਡੇਟਾਬੇਸ ਵਿੱਚ ਸਟੋਰ ਕੀਤੀ ਜਾਂਦੀ ਹੈ)
                processStatusRepository.updateStatus(processId, "completed");
            } catch (Exception ex) {
                processStatusRepository.updateStatus(processId, "failed", ex.getMessage());
            }
        }, executorService);
        
        // ਤੁਰੰਤ ਜਵਾਬ ਪ੍ਰੋਸੈਸ ID ਨਾਲ ਵਾਪਸ ਕਰੋ
        Map<String, Object> result = new HashMap<>();
        result.put("processId", processId);
        result.put("status", "processing");
        result.put("estimatedCompletionTime", ZonedDateTime.now().plusMinutes(5));
        
        return new ToolResponse.Builder().setResult(result).build();
    }
    
    // ਸਾਥੀ ਸਥਿਤੀ ਜਾਂਚ ਟੂਲ
    public class ProcessStatusTool implements Tool {
        @Override
        public ToolResponse execute(ToolRequest request) {
            String processId = request.getParameters().get("processId").asText();
            ProcessStatus status = processStatusRepository.getStatus(processId);
            
            return new ToolResponse.Builder().setResult(status).build();
        }
    }
}
```

#### 3. Resource Throttling

Implement resource throttling to prevent overload:

```python
class ThrottledApiTool(Tool):
    def __init__(self):
        self.rate_limiter = TokenBucketRateLimiter(
            tokens_per_second=5,  # ਪ੍ਰਤੀ ਸਕਿੰਟ 5 ਬੇਨਤੀਆਂ ਦੀ ਆਗਿਆ
            bucket_size=10        # 10 ਬੇਨਤੀਆਂ ਤੱਕ ਬਰਸਟ ਦੀ ਆਗਿਆ
        )
    
    async def execute_async(self, request):
        # ਜਾਂਚੋ ਕਿ ਅਸੀਂ ਅੱਗੇ ਵਧ ਸਕਦੇ ਹਾਂ ਜਾਂ ਰੁਕਣਾ ਪਵੇਗਾ
        delay = self.rate_limiter.get_delay_time()
        
        if delay > 0:
            if delay > 2.0:  # ਜੇ ਇੰਤਜ਼ਾਰ ਬਹੁਤ ਲੰਮਾ ਹੈ
                raise ToolExecutionException(
                    f"Rate limit exceeded. Please try again in {delay:.1f} seconds."
                )
            else:
                # ਉਚਿਤ ਇੰਤਜ਼ਾਰ ਸਮਾਂ ਲਈ ਰੁਕੋ
                await asyncio.sleep(delay)
        
        # ਇੱਕ ਟੋਕਨ ਖਪਤ ਕਰੋ ਅਤੇ ਬੇਨਤੀ ਨਾਲ ਅੱਗੇ ਵਧੋ
        self.rate_limiter.consume()
        
        # API ਕਾਲ ਕਰੋ
        result = await self._call_api(request.parameters)
        return ToolResponse(result=result)

class TokenBucketRateLimiter:
    def __init__(self, tokens_per_second, bucket_size):
        self.tokens_per_second = tokens_per_second
        self.bucket_size = bucket_size
        self.tokens = bucket_size
        self.last_refill = time.time()
        self.lock = asyncio.Lock()
    
    async def get_delay_time(self):
        async with self.lock:
            self._refill()
            if self.tokens >= 1:
                return 0
            
            # ਅਗਲੇ ਟੋਕਨ ਦੀ ਉਪਲਬਧਤਾ ਤੱਕ ਸਮਾਂ ਗਿਣੋ
            return (1 - self.tokens) / self.tokens_per_second
    
    async def consume(self):
        async with self.lock:
            self._refill()
            self.tokens -= 1
    
    def _refill(self):
        now = time.time()
        elapsed = now - self.last_refill
        
        # ਬੀਤੇ ਸਮੇਂ ਦੇ ਆਧਾਰ 'ਤੇ ਨਵੇਂ ਟੋਕਨ ਜੋੜੋ
        new_tokens = elapsed * self.tokens_per_second
        self.tokens = min(self.bucket_size, self.tokens + new_tokens)
        self.last_refill = now
```

### Security Best Practices

#### 1. Input Validation

Always validate input parameters thoroughly:

```csharp
public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
{
    // ਪੈਰਾਮੀਟਰ ਮੌਜੂਦ ਹਨ ਜਾਂ ਨਹੀਂ ਜਾਂਚੋ
    if (!request.Parameters.TryGetProperty("query", out var queryProp))
    {
        throw new ToolExecutionException("Missing required parameter: query");
    }
    
    // ਸਹੀ ਕਿਸਮ ਦੀ ਜਾਂਚ ਕਰੋ
    if (queryProp.ValueKind != JsonValueKind.String)
    {
        throw new ToolExecutionException("Query parameter must be a string");
    }
    
    var query = queryProp.GetString();
    
    // ਸਤਰ ਦੀ ਸਮੱਗਰੀ ਦੀ ਜਾਂਚ ਕਰੋ
    if (string.IsNullOrWhiteSpace(query))
    {
        throw new ToolExecutionException("Query parameter cannot be empty");
    }
    
    if (query.Length > 500)
    {
        throw new ToolExecutionException("Query parameter exceeds maximum length of 500 characters");
    }
    
    // ਜੇ ਲਾਗੂ ਹੋਵੇ ਤਾਂ SQL injection ਹਮਲਿਆਂ ਲਈ ਜਾਂਚ ਕਰੋ
    if (ContainsSqlInjection(query))
    {
        throw new ToolExecutionException("Invalid query: contains potentially unsafe SQL");
    }
    
    // ਕਾਰਜਵਾਹੀ ਨਾਲ ਅੱਗੇ ਵਧੋ
    // ...
}
```

#### 2. Authorization Checks

Implement proper authorization checks:

```java
@Override
public ToolResponse execute(ToolRequest request) {
    // ਬੇਨਤੀ ਤੋਂ ਯੂਜ਼ਰ ਸੰਦਰਭ ਪ੍ਰਾਪਤ ਕਰੋ
    UserContext user = request.getContext().getUserContext();
    
    // ਜਾਂਚੋ ਕਿ ਯੂਜ਼ਰ ਕੋਲ ਲੋੜੀਂਦੇ ਅਧਿਕਾਰ ਹਨ
    if (!authorizationService.hasPermission(user, "documents:read")) {
        throw new ToolExecutionException("User does not have permission to access documents");
    }
    
    // ਖਾਸ ਸਰੋਤਾਂ ਲਈ, ਉਸ ਸਰੋਤ ਤੱਕ ਪਹੁੰਚ ਦੀ ਜਾਂਚ ਕਰੋ
    String documentId = request.getParameters().get("documentId").asText();
    if (!documentService.canUserAccess(user.getId(), documentId)) {
        throw new ToolExecutionException("Access denied to the requested document");
    }
    
    // ਟੂਲ ਕਾਰਜਵਾਹੀ ਨਾਲ ਅੱਗੇ ਵਧੋ
    // ...
}
```

#### 3. Sensitive Data Handling

Handle sensitive data carefully:

```python
class SecureDataTool(Tool):
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "userId": {"type": "string"},
                "includeSensitiveData": {"type": "boolean", "default": False}
            },
            "required": ["userId"]
        }
    
    async def execute_async(self, request):
        user_id = request.parameters["userId"]
        include_sensitive = request.parameters.get("includeSensitiveData", False)
        
        # ਯੂਜ਼ਰ ਡੇਟਾ ਪ੍ਰਾਪਤ ਕਰੋ
        user_data = await self.user_service.get_user_data(user_id)
        
        # ਸੰਵੇਦਨਸ਼ੀਲ ਖੇਤਰਾਂ ਨੂੰ ਛਾਂਟੋ ਜਦ ਤੱਕ ਖਾਸ ਤੌਰ 'ਤੇ ਮੰਗਿਆ ਨਾ ਗਿਆ ਹੋਵੇ ਅਤੇ ਅਧਿਕਾਰਤ ਨਾ ਹੋਵੇ
        if not include_sensitive or not self._is_authorized_for_sensitive_data(request):
            user_data = self._redact_sensitive_fields(user_data)
        
        return ToolResponse(result=user_data)
    
    def _is_authorized_for_sensitive_data(self, request):
        // ਬੇਨਤੀ ਸੰਦਰਭ ਵਿੱਚ ਅਧਿਕਾਰ ਪੱਧਰ ਦੀ ਜਾਂਚ ਕਰੋ
        auth_level = request.context.get("authorizationLevel")
        return auth_level == "admin"
    
    def _redact_sensitive_fields(self, user_data):
        // ਮੂਲ ਨੂੰ ਬਦਲਣ ਤੋਂ ਬਚਣ ਲਈ ਨਕਲ ਬਣਾਓ
        redacted = user_data.copy()
        
        // ਖਾਸ ਸੰਵੇਦਨਸ਼ੀਲ ਖੇਤਰਾਂ ਨੂੰ ਛਾਂਟੋ
        sensitive_fields = ["ssn", "creditCardNumber", "password"]
        for field in sensitive_fields:
            if field in redacted:
                redacted[field] = "REDACTED"
        
        // ਘੁੰਮਾਫਿਰ ਕੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਨੂੰ ਛਾਂਟੋ
        if "financialInfo" in redacted:
            redacted["financialInfo"] = {"available": True, "accessRestricted": True}
        
        return redacted
```

## Testing Best Practices for MCP Tools

Comprehensive testing ensures that MCP tools function correctly, handle edge cases, and integrate properly with the rest of the system.

### Unit Testing

#### 1. Test Each Tool in Isolation

Create focused tests for each tool's functionality:

```csharp
[Fact]
public async Task WeatherTool_ValidLocation_ReturnsCorrectForecast()
{
    // ਤਿਆਰੀ
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("Seattle", 3))
        .ReturnsAsync(new WeatherForecast(/* ਟੈਸਟ ਡੇਟਾ */));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "Seattle", 
            days = 3 
        })
    );
    
    // ਕਾਰਜ
    var response = await tool.ExecuteAsync(request);
    
    // ਪੁਸ਼ਟੀ
    Assert.NotNull(response);
    var result = JsonSerializer.Deserialize<WeatherForecast>(response.Result);
    Assert.Equal("Seattle", result.Location);
    Assert.Equal(3, result.DailyForecasts.Count);
}

[Fact]
public async Task WeatherTool_InvalidLocation_ThrowsToolExecutionException()
{
    // ਤਿਆਰੀ
    var mockWeatherService = new Mock<IWeatherService>();
    mockWeatherService
        .Setup(s => s.GetForecastAsync("InvalidLocation", It.IsAny<int>()))
        .ThrowsAsync(new LocationNotFoundException("Location not found"));
    
    var tool = new WeatherForecastTool(mockWeatherService.Object);
    
    var request = new ToolRequest(
        toolName: "weatherForecast",
        parameters: JsonSerializer.SerializeToElement(new { 
            location = "InvalidLocation", 
            days = 3 
        })
    );
    
    // ਕਾਰਜ ਅਤੇ ਪੁਸ਼ਟੀ
    var exception = await Assert.ThrowsAsync<ToolExecutionException>(
        () => tool.ExecuteAsync(request)
    );
    
    Assert.Contains("Location not found", exception.Message);
}
```

#### 2. Schema Validation Testing

Test that schemas are valid and properly enforce constraints:

```java
@Test
public void testSchemaValidation() {
    // ਟੂਲ ਇੰਸਟੈਂਸ ਬਣਾਓ
    SearchTool searchTool = new SearchTool();
    
    // ਸਕੀਮਾ ਪ੍ਰਾਪਤ ਕਰੋ
    Object schema = searchTool.getSchema();
    
    // ਸਕੀਮਾ ਨੂੰ JSON ਵਿੱਚ ਬਦਲੋ ਤਾਕਿ ਵੈਧਤਾ ਦੀ ਜਾਂਚ ਹੋ ਸਕੇ
    String schemaJson = objectMapper.writeValueAsString(schema);
    
    // ਜਾਂਚੋ ਕਿ ਸਕੀਮਾ ਵੈਧ JSONSchema ਹੈ
    JsonSchemaFactory factory = JsonSchemaFactory.byDefault();
    JsonSchema jsonSchema = factory.getJsonSchema(schemaJson);
    
    // ਵੈਧ ਪੈਰਾਮੀਟਰਾਂ ਦੀ ਜਾਂਚ ਕਰੋ
    JsonNode validParams = objectMapper.createObjectNode()
        .put("query", "test query")
        .put("limit", 5);
        
    ProcessingReport validReport = jsonSchema.validate(validParams);
    assertTrue(validReport.isSuccess());
    
    // ਲੋੜੀਂਦੇ ਪੈਰਾਮੀਟਰ ਦੀ ਗੈਰਹਾਜ਼ਰੀ ਦੀ ਜਾਂਚ ਕਰੋ
    JsonNode missingRequired = objectMapper.createObjectNode()
        .put("limit", 5);
        
    ProcessingReport missingReport = jsonSchema.validate(missingRequired);
    assertFalse(missingReport.isSuccess());
    
    // ਗਲਤ ਕਿਸਮ ਦੇ ਪੈਰਾਮੀਟਰ ਦੀ ਜਾਂਚ ਕਰੋ
    JsonNode invalidType = objectMapper.createObjectNode()
        .put("query", "test")
        .put("limit", "not-a-number");
        
    ProcessingReport invalidReport = jsonSchema.validate(invalidType);
    assertFalse(invalidReport.isSuccess());
}
```

#### 3. Error Handling Tests

Create specific tests for error conditions:

```python
@pytest.mark.asyncio
async def test_api_tool_handles_timeout():
    # ਤਿਆਰੀ
    tool = ApiTool(timeout=0.1)  # ਬਹੁਤ ਛੋਟਾ timeout
    
    # ਇੱਕ ਬੇਨਤੀ ਜੋ timeout ਕਰੇਗੀ, ਮੌਕ ਕਰੋ
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            callback=lambda *args, **kwargs: asyncio.sleep(0.5)  # timeout ਤੋਂ ਵੱਧ ਸਮਾਂ
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # ਕਾਰਜ ਅਤੇ ਪੁਸ਼ਟੀ
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # ਐਕਸਪਸ਼ਨ ਸੁਨੇਹਾ ਦੀ ਜਾਂਚ ਕਰੋ
        assert "timed out" in str(exc_info.value).lower()

@pytest.mark.asyncio
async def test_api_tool_handles_rate_limiting():
    # ਤਿਆਰੀ
    tool = ApiTool()
    
    # ਰੇਟ-ਲਿਮਿਟਡ ਜਵਾਬ ਮੌਕ ਕਰੋ
    with aioresponses() as mocked:
        mocked.get(
            "https://api.example.com/data",
            status=429,
            headers={"Retry-After": "2"},
            body=json.dumps({"error": "Rate limit exceeded"})
        )
        
        request = ToolRequest(
            tool_name="apiTool",
            parameters={"url": "https://api.example.com/data"}
        )
        
        # ਕਾਰਜ ਅਤੇ ਪੁਸ਼ਟੀ
        with pytest.raises(ToolExecutionException) as exc_info:
            await tool.execute_async(request)
        
        # ਐਕਸਪਸ਼ਨ ਵਿੱਚ ਰੇਟ ਲਿਮਿਟ ਜਾਣਕਾਰੀ ਦੀ ਜਾਂਚ ਕਰੋ
        error_msg = str(exc_info.value).lower()
        assert "rate limit" in error_msg
        assert "try again" in error_msg
```

### Integration Testing

#### 1. Tool Chain Testing

Test tools working together in expected combinations:

```csharp
[Fact]
public async Task DataProcessingWorkflow_CompletesSuccessfully()
{
    // ਤਿਆਰੀ
    var dataFetchTool = new DataFetchTool(mockDataService.Object);
    var analysisTools = new DataAnalysisTool(mockAnalysisService.Object);
    var visualizationTool = new DataVisualizationTool(mockVisualizationService.Object);
    
    var toolRegistry = new ToolRegistry();
    toolRegistry.RegisterTool(dataFetchTool);
    toolRegistry.RegisterTool(analysisTools);
    toolRegistry.RegisterTool(visualizationTool);
    
    var workflowExecutor = new WorkflowExecutor(toolRegistry);
    
    // ਕਾਰਜ
IMPORTANT RULES:
1. ਅਨੁਵਾਦ ਦੇ ਆਲੇ-ਦੁਆਲੇ '''markdown ਜਾਂ ਹੋਰ ਕਿਸੇ ਟੈਗ ਨੂੰ ਨਾ ਜੋੜੋ
2. ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਅਨੁਵਾਦ ਬਹੁਤ ਜ਼ਿਆਦਾ ਸ਼ਾਬਦਿਕ ਨਾ ਲੱਗੇ
3. ਟਿੱਪਣੀਆਂ ਦਾ ਵੀ ਅਨੁਵਾਦ ਕਰੋ
4. ਇਹ ਫਾਇਲ Markdown ਫਾਰਮੈਟ ਵਿੱਚ ਲਿਖੀ ਗਈ ਹੈ - ਇਸਨੂੰ XML ਜਾਂ HTML ਵਾਂਗ ਨਾ ਸਮਝੋ
5. ਅਨੁਵਾਦ ਨਾ ਕਰੋ:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ਵੈਰੀਏਬਲ ਨਾਮ, ਫੰਕਸ਼ਨ ਨਾਮ, ਕਲਾਸ ਨਾਮ
   - ਪਲੇਸਹੋਲਡਰ ਜਿਵੇਂ @@INLINE_CODE_x@@ ਜਾਂ @@CODE_BLOCK_x@@
   - URLs ਜਾਂ ਪਾਥ
6. ਸਾਰੇ ਮੂਲ markdown ਫਾਰਮੈਟਿੰਗ ਨੂੰ ਬਰਕਰਾਰ ਰੱਖੋ
7. ਸਿਰਫ ਅਨੁਵਾਦਿਤ ਸਮੱਗਰੀ ਵਾਪਸ ਕਰੋ, ਕਿਸੇ ਹੋਰ ਟੈਗ ਜਾਂ ਮਾਰਕਅੱਪ ਦੇ ਬਿਨਾਂ
ਕਿਰਪਾ ਕਰਕੇ ਨਤੀਜਾ ਖੱਬੇ ਤੋਂ ਸੱਜੇ ਲਿਖੋ।

var result = await workflowExecutor.ExecuteWorkflowAsync(new[] {
    new ToolCall("dataFetch", new { source = "sales2023" }),
    new ToolCall("dataAnalysis", ctx =>
        new { 
            data = ctx.GetResult("dataFetch"),
            analysis = "trend" 
        }),
    new ToolCall("dataVisualize", ctx => new {
        analysisResult = ctx.GetResult("dataAnalysis"),
        type = "line-chart"
    })
});

// Assert
Assert.NotNull(result);
Assert.True(result.Success);
Assert.NotNull(result.GetResult("dataVisualize"));
Assert.Contains("chartUrl", result.GetResult("dataVisualize").ToString());
}
```

#### 2. MCP Server Testing

Test the MCP server with full tool registration and execution:

```java
@SpringBootTest
@AutoConfigureMockMvc
public class McpServerIntegrationTest {
    
    @Autowired
    private MockMvc mockMvc;
    
    @Autowired
    private ObjectMapper objectMapper;
    
    @Test
    public void testToolDiscovery() throws Exception {
        // ਡਿਸਕਵਰੀ ਐਂਡਪੌਇੰਟ ਦੀ ਜਾਂਚ ਕਰੋ
        mockMvc.perform(get("/mcp/tools"))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.tools").isArray())
            .andExpect(jsonPath("$.tools[*].name").value(hasItems(
                "weatherForecast", "calculator", "documentSearch"
            )));
    }
    
    @Test
    public void testToolExecution() throws Exception {
        // ਟੂਲ ਰਿਕਵੇਸਟ ਬਣਾਓ
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "add");
        parameters.put("a", 5);
        parameters.put("b", 7);
        request.put("parameters", parameters);
        
        // ਰਿਕਵੇਸਟ ਭੇਜੋ ਅਤੇ ਜਵਾਬ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isOk())
            .andExpect(jsonPath("$.result.value").value(12));
    }
    
    @Test
    public void testToolValidation() throws Exception {
        // ਗਲਤ ਟੂਲ ਰਿਕਵੇਸਟ ਬਣਾਓ
        Map<String, Object> request = new HashMap<>();
        request.put("toolName", "calculator");
        
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("operation", "divide");
        parameters.put("a", 10);
        // ਪੈਰਾਮੀਟਰ "b" ਗੁੰਮ ਹੈ
        request.put("parameters", parameters);
        
        // ਰਿਕਵੇਸਟ ਭੇਜੋ ਅਤੇ ਗਲਤੀ ਵਾਲਾ ਜਵਾਬ ਚੈੱਕ ਕਰੋ
        mockMvc.perform(post("/mcp/execute")
            .contentType(MediaType.APPLICATION_JSON)
            .content(objectMapper.writeValueAsString(request)))
            .andExpect(status().isBadRequest())
            .andExpect(jsonPath("$.error").exists());
    }
}
```

#### 3. End-to-End Testing

Test complete workflows from model prompt to tool execution:

```python
@pytest.mark.asyncio
async def test_model_interaction_with_tool():
    # ਤਿਆਰੀ - MCP ਕਲਾਇੰਟ ਅਤੇ ਮੌਕ ਮਾਡਲ ਸੈੱਟ ਕਰੋ
    mcp_client = McpClient(server_url="http://localhost:5000")
    
    # ਮੌਕ ਮਾਡਲ ਦੇ ਜਵਾਬ
    mock_model = MockLanguageModel([
        MockResponse(
            "ਸੀਏਟਲ ਵਿੱਚ ਮੌਸਮ ਕਿਵੇਂ ਹੈ?",
            tool_calls=[{
                "tool_name": "weatherForecast",
                "parameters": {"location": "Seattle", "days": 3}
            }]
        ),
        MockResponse(
            "ਇਹ ਰਹੀ ਸੀਏਟਲ ਦੀ ਮੌਸਮ ਭਵਿੱਖਬਾਣੀ:\n- ਅੱਜ: 65°F, ਹਲਕਾ ਬਦਲੀਲਾ\n- ਕੱਲ੍ਹ: 68°F, ਧੁੱਪ ਵਾਲਾ\n- ਪਰਸੋਂ: 62°F, ਮੀਂਹ",
            tool_calls=[]
        )
    ])
    
    # ਮੌਸਮ ਟੂਲ ਦਾ ਮੌਕ ਜਵਾਬ
    with aioresponses() as mocked:
        mocked.post(
            "http://localhost:5000/mcp/execute",
            payload={
                "result": {
                    "location": "Seattle",
                    "forecast": [
                        {"date": "2023-06-01", "temperature": 65, "conditions": "Partly Cloudy"},
                        {"date": "2023-06-02", "temperature": 68, "conditions": "Sunny"},
                        {"date": "2023-06-03", "temperature": 62, "conditions": "Rain"}
                    ]
                }
            }
        )
        
        # ਕਾਰਵਾਈ
        response = await mcp_client.send_prompt(
            "ਸੀਏਟਲ ਵਿੱਚ ਮੌਸਮ ਕਿਵੇਂ ਹੈ?",
            model=mock_model,
            allowed_tools=["weatherForecast"]
        )
        
        # ਪੁਸ਼ਟੀ
        assert "Seattle" in response.generated_text
        assert "65" in response.generated_text
        assert "Sunny" in response.generated_text
        assert "Rain" in response.generated_text
        assert len(response.tool_calls) == 1
        assert response.tool_calls[0].tool_name == "weatherForecast"
```

### Performance Testing

#### 1. Load Testing

Test how many concurrent requests your MCP server can handle:

```csharp
[Fact]
public async Task McpServer_HandlesHighConcurrency()
{
    // ਤਿਆਰੀ
    var server = new McpServer(
        name: "TestServer",
        version: "1.0",
        maxConcurrentRequests: 100
    );
    
    server.RegisterTool(new FastExecutingTool());
    await server.StartAsync();
    
    var client = new McpClient("http://localhost:5000");
    
    // ਕਾਰਵਾਈ
    var tasks = new List<Task<McpResponse>>();
    for (int i = 0; i < 1000; i++)
    {
        tasks.Add(client.ExecuteToolAsync("fastTool", new { iteration = i }));
    }
    
    var results = await Task.WhenAll(tasks);
    
    // ਪੁਸ਼ਟੀ
    Assert.Equal(1000, results.Length);
    Assert.All(results, r => Assert.NotNull(r));
}
```

#### 2. Stress Testing

Test the system under extreme load:

```java
@Test
public void testServerUnderStress() {
    int maxUsers = 1000;
    int rampUpTimeSeconds = 60;
    int testDurationSeconds = 300;
    
    // ਸਟ੍ਰੈੱਸ ਟੈਸਟ ਲਈ JMeter ਸੈੱਟ ਕਰੋ
    StandardJMeterEngine jmeter = new StandardJMeterEngine();
    
    // JMeter ਟੈਸਟ ਪਲਾਨ ਕਨਫਿਗਰ ਕਰੋ
    HashTree testPlanTree = new HashTree();
    
    // ਟੈਸਟ ਪਲਾਨ, ਥ੍ਰੈਡ ਗਰੁੱਪ, ਸੈਂਪਲਰ ਆਦਿ ਬਣਾਓ
    TestPlan testPlan = new TestPlan("MCP Server Stress Test");
    testPlanTree.add(testPlan);
    
    ThreadGroup threadGroup = new ThreadGroup();
    threadGroup.setNumThreads(maxUsers);
    threadGroup.setRampUp(rampUpTimeSeconds);
    threadGroup.setScheduler(true);
    threadGroup.setDuration(testDurationSeconds);
    
    testPlanTree.add(threadGroup);
    
    // ਟੂਲ ਐਗਜ਼ਿਕਿਊਸ਼ਨ ਲਈ HTTP ਸੈਂਪਲਰ ਜੋੜੋ
    HTTPSampler toolExecutionSampler = new HTTPSampler();
    toolExecutionSampler.setDomain("localhost");
    toolExecutionSampler.setPort(5000);
    toolExecutionSampler.setPath("/mcp/execute");
    toolExecutionSampler.setMethod("POST");
    toolExecutionSampler.addArgument("toolName", "calculator");
    toolExecutionSampler.addArgument("parameters", "{\"operation\":\"add\",\"a\":5,\"b\":7}");
    
    threadGroup.add(toolExecutionSampler);
    
    // ਲਿਸਨਰ ਜੋੜੋ
    SummaryReport summaryReport = new SummaryReport();
    threadGroup.add(summaryReport);
    
    // ਟੈਸਟ ਚਲਾਓ
    jmeter.configure(testPlanTree);
    jmeter.run();
    
    // ਨਤੀਜੇ ਵੈਰੀਫਾਈ ਕਰੋ
    assertEquals(0, summaryReport.getErrorCount());
    assertTrue(summaryReport.getAverage() < 200); // ਔਸਤ ਜਵਾਬ ਸਮਾਂ < 200ms
    assertTrue(summaryReport.getPercentile(90.0) < 500); // 90ਵਾਂ ਪ੍ਰਤੀਸ਼ਤ < 500ms
}
```

#### 3. Monitoring and Profiling

Set up monitoring for long-term performance analysis:

```python
# MCP ਸਰਵਰ ਲਈ ਮਾਨੀਟਰਿੰਗ ਕਨਫਿਗਰ ਕਰੋ
def configure_monitoring(server):
    # Prometheus ਮੈਟ੍ਰਿਕਸ ਸੈੱਟ ਕਰੋ
    prometheus_metrics = {
        "request_count": Counter("mcp_requests_total", "ਕੁੱਲ MCP ਬੇਨਤੀਆਂ"),
        "request_latency": Histogram(
            "mcp_request_duration_seconds", 
            "ਬੇਨਤੀ ਦੀ ਮਿਆਦ ਸਕਿੰਟਾਂ ਵਿੱਚ",
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_execution_count": Counter(
            "mcp_tool_executions_total", 
            "ਟੂਲ ਐਗਜ਼ਿਕਿਊਸ਼ਨ ਗਿਣਤੀ",
            labelnames=["tool_name"]
        ),
        "tool_execution_latency": Histogram(
            "mcp_tool_duration_seconds", 
            "ਟੂਲ ਐਗਜ਼ਿਕਿਊਸ਼ਨ ਮਿਆਦ ਸਕਿੰਟਾਂ ਵਿੱਚ",
            labelnames=["tool_name"],
            buckets=[0.01, 0.05, 0.1, 0.5, 1.0, 2.5, 5.0, 10.0]
        ),
        "tool_errors": Counter(
            "mcp_tool_errors_total",
            "ਟੂਲ ਐਗਜ਼ਿਕਿਊਸ਼ਨ ਗਲਤੀਆਂ",
            labelnames=["tool_name", "error_type"]
        )
    }
    
    # ਸਮਾਂ ਮਾਪਣ ਅਤੇ ਮੈਟ੍ਰਿਕਸ ਰਿਕਾਰਡ ਕਰਨ ਲਈ ਮਿਡਲਵੇਅਰ ਜੋੜੋ
    server.add_middleware(PrometheusMiddleware(prometheus_metrics))
    
    # ਮੈਟ੍ਰਿਕਸ ਐਂਡਪੌਇੰਟ ਖੋਲ੍ਹੋ
    @server.router.get("/metrics")
    async def metrics():
        return generate_latest()
    
    return server
```

## MCP Workflow Design Patterns

Well-designed MCP workflows improve efficiency, reliability, and maintainability. Here are key patterns to follow:

### 1. Chain of Tools Pattern

Connect multiple tools in a sequence where each tool's output becomes the input for the next:

```python
# Python ਵਿੱਚ Chain of Tools ਦੀ ਲਾਗੂਆਈ
class ChainWorkflow:
    def __init__(self, tools_chain):
        self.tools_chain = tools_chain  # ਲੜੀਵਾਰ ਚਲਾਉਣ ਲਈ ਟੂਲਾਂ ਦੀ ਸੂਚੀ
    
    async def execute(self, mcp_client, initial_input):
        current_result = initial_input
        all_results = {"input": initial_input}
        
        for tool_name in self.tools_chain:
            # ਹਰ ਟੂਲ ਚਲਾਓ, ਪਿਛਲੇ ਨਤੀਜੇ ਨੂੰ ਇਨਪੁੱਟ ਵਜੋਂ ਦੇ ਕੇ
            response = await mcp_client.execute_tool(tool_name, current_result)
            
            # ਨਤੀਜਾ ਸਟੋਰ ਕਰੋ ਅਤੇ ਅਗਲੇ ਲਈ ਇਨਪੁੱਟ ਬਣਾਓ
            all_results[tool_name] = response.result
            current_result = response.result
        
        return {
            "final_result": current_result,
            "all_results": all_results
        }

# ਉਦਾਹਰਨ ਵਜੋਂ ਵਰਤੋਂ
data_processing_chain = ChainWorkflow([
    "dataFetch",
    "dataCleaner",
    "dataAnalyzer",
    "dataVisualizer"
])

result = await data_processing_chain.execute(
    mcp_client,
    {"source": "sales_database", "table": "transactions"}
)
```

### 2. Dispatcher Pattern

Use a central tool that dispatches to specialized tools based on input:

```csharp
public class ContentDispatcherTool : IMcpTool
{
    private readonly IMcpClient _mcpClient;
    
    public ContentDispatcherTool(IMcpClient mcpClient)
    {
        _mcpClient = mcpClient;
    }
    
    public string Name => "contentProcessor";
    public string Description => "ਵੱਖ-ਵੱਖ ਕਿਸਮਾਂ ਦੇ ਸਮੱਗਰੀ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦਾ ਹੈ";
    
    public object GetSchema()
    {
        return new {
            type = "object",
            properties = new {
                content = new { type = "string" },
                contentType = new { 
                    type = "string",
                    enum = new[] { "text", "html", "markdown", "csv", "code" }
                },
                operation = new { 
                    type = "string",
                    enum = new[] { "summarize", "analyze", "extract", "convert" }
                }
            },
            required = new[] { "content", "contentType", "operation" }
        };
    }
    
    public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
    {
        var content = request.Parameters.GetProperty("content").GetString();
        var contentType = request.Parameters.GetProperty("contentType").GetString();
        var operation = request.Parameters.GetProperty("operation").GetString();
        
        // ਇਹ ਪਤਾ ਲਗਾਓ ਕਿ ਕਿਹੜਾ ਵਿਸ਼ੇਸ਼ ਟੂਲ ਵਰਤਣਾ ਹੈ
        string targetTool = DetermineTargetTool(contentType, operation);
        
        // ਵਿਸ਼ੇਸ਼ ਟੂਲ ਨੂੰ ਅੱਗੇ ਭੇਜੋ
        var specializedResponse = await _mcpClient.ExecuteToolAsync(
            targetTool,
            new { content, options = GetOptionsForTool(targetTool, operation) }
        );
        
        return new ToolResponse { Result = specializedResponse.Result };
    }
    
    private string DetermineTargetTool(string contentType, string operation)
    {
        return (contentType, operation) switch
        {
            ("text", "summarize") => "textSummarizer",
            ("text", "analyze") => "textAnalyzer",
            ("html", _) => "htmlProcessor",
            ("markdown", _) => "markdownProcessor",
            ("csv", _) =>
IMPORTANT RULES:
1. ਅਨੁਵਾਦ ਦੇ ਆਲੇ-ਦੁਆਲੇ '''markdown ਜਾਂ ਹੋਰ ਕਿਸੇ ਵੀ ਟੈਗ ਨੂੰ ਨਾ ਜੋੜੋ
2. ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਅਨੁਵਾਦ ਬਹੁਤ ਜ਼ਿਆਦਾ ਸ਼ਾਬਦਿਕ ਨਾ ਲੱਗੇ
3. ਟਿੱਪਣੀਆਂ ਦਾ ਵੀ ਅਨੁਵਾਦ ਕਰੋ
4. ਇਹ ਫਾਈਲ Markdown ਫਾਰਮੈਟ ਵਿੱਚ ਲਿਖੀ ਗਈ ਹੈ - ਇਸਨੂੰ XML ਜਾਂ HTML ਵਾਂਗ ਨਾ ਸਮਝੋ
5. ਅਨੁਵਾਦ ਨਾ ਕਰੋ:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ਵੈਰੀਏਬਲ ਨਾਮ, ਫੰਕਸ਼ਨ ਨਾਮ, ਕਲਾਸ ਨਾਮ
   - @@INLINE_CODE_x@@ ਜਾਂ @@CODE_BLOCK_x@@ ਵਰਗੇ ਪਲੇਸਹੋਲਡਰ
   - URLs ਜਾਂ ਪਾਥ
6. ਸਾਰੇ ਮੂਲ markdown ਫਾਰਮੈਟਿੰਗ ਨੂੰ ਬਰਕਰਾਰ ਰੱਖੋ
7. ਸਿਰਫ ਅਨੁਵਾਦਿਤ ਸਮੱਗਰੀ ਵਾਪਸ ਕਰੋ, ਕਿਸੇ ਹੋਰ ਟੈਗ ਜਾਂ ਮਾਰਕਅੱਪ ਦੇ ਬਿਨਾਂ
IMPORTANT RULES:
1. ਅਨੁਵਾਦ ਦੇ ਆਲੇ-ਦੁਆਲੇ '''markdown ਜਾਂ ਹੋਰ ਕਿਸੇ ਵੀ ਟੈਗ ਨਾ ਜੋੜੋ
2. ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਅਨੁਵਾਦ ਬਹੁਤ ਜ਼ਿਆਦਾ ਸ਼ਾਬਦਿਕ ਨਾ ਲੱਗੇ
3. ਟਿੱਪਣੀਆਂ ਦਾ ਵੀ ਅਨੁਵਾਦ ਕਰੋ
4. ਇਹ ਫਾਇਲ Markdown ਫਾਰਮੈਟ ਵਿੱਚ ਹੈ - ਇਸਨੂੰ XML ਜਾਂ HTML ਵਾਂਗ ਨਾ ਸਮਝੋ
5. ਅਨੁਵਾਦ ਨਾ ਕਰੋ:
   - [!NOTE], [!WARNING], [!TIP], [!IMPORTANT], [!CAUTION]
   - ਵੈਰੀਏਬਲ ਨਾਮ, ਫੰਕਸ਼ਨ ਨਾਮ, ਕਲਾਸ ਨਾਮ
   - ਜਗ੍ਹਾ ਰੱਖਣ ਵਾਲੇ ਜਿਵੇਂ @@INLINE_CODE_x@@ ਜਾਂ @@CODE_BLOCK_x@@
   - URLs ਜਾਂ ਪਾਥ
6. ਸਾਰੇ ਮੂਲ markdown ਫਾਰਮੈਟਿੰਗ ਨੂੰ ਬਰਕਰਾਰ ਰੱਖੋ
7. ਸਿਰਫ ਅਨੁਵਾਦਿਤ ਸਮੱਗਰੀ ਵਾਪਸ ਕਰੋ, ਕੋਈ ਵਾਧੂ ਟੈਗ ਜਾਂ ਮਾਰਕਅਪ ਨਾ ਜੋੜੋ
ਕਿਰਪਾ ਕਰਕੇ ਨਤੀਜਾ ਖੱਬੇ ਤੋਂ ਸੱਜੇ ਲਿਖੋ।

("code", _) => "codeAnalyzer",
_ => throw new ToolExecutionException($"No tool available for {contentType}/{operation}")
};
}

private object GetOptionsForTool(string toolName, string operation)
{
// ਹਰ ਵਿਸ਼ੇਸ਼ ਟੂਲ ਲਈ ਉਚਿਤ ਵਿਕਲਪ ਵਾਪਸ ਕਰੋ
return toolName switch
{
"textSummarizer" => new { length = "medium" },
"htmlProcessor" => new { cleanUp = true, operation },
// ਹੋਰ ਟੂਲਾਂ ਲਈ ਵਿਕਲਪ...
_ => new { }
};
}
}
```

### 3. Parallel Processing Pattern

Execute multiple tools simultaneously for efficiency:

```java
public class ParallelDataProcessingWorkflow {
private final McpClient mcpClient;

public ParallelDataProcessingWorkflow(McpClient mcpClient) {
this.mcpClient = mcpClient;
}

public WorkflowResult execute(String datasetId) {
// ਕਦਮ 1: ਡੇਟਾਸੈੱਟ ਮੈਟਾਡੇਟਾ ਪ੍ਰਾਪਤ ਕਰੋ (ਸਿੰਕ੍ਰੋਨਸ)
ToolResponse metadataResponse = mcpClient.executeTool("datasetMetadata",
Map.of("datasetId", datasetId));

// ਕਦਮ 2: ਬਹੁਤ ਸਾਰੀਆਂ ਵਿਸ਼ਲੇਸ਼ਣਾਂ ਇਕੱਠੇ ਚਲਾਓ
CompletableFuture<ToolResponse> statisticalAnalysis = CompletableFuture.supplyAsync(() ->
mcpClient.executeTool("statisticalAnalysis", Map.of(
"datasetId", datasetId,
"type", "comprehensive"
))
);

CompletableFuture<ToolResponse> correlationAnalysis = CompletableFuture.supplyAsync(() ->
mcpClient.executeTool("correlationAnalysis", Map.of(
"datasetId", datasetId,
"method", "pearson"
))
);

CompletableFuture<ToolResponse> outlierDetection = CompletableFuture.supplyAsync(() ->
mcpClient.executeTool("outlierDetection", Map.of(
"datasetId", datasetId,
"sensitivity", "medium"
))
);

// ਸਾਰੇ ਸਮਕਾਲੀ ਕੰਮਾਂ ਦੇ ਪੂਰੇ ਹੋਣ ਦੀ ਉਡੀਕ ਕਰੋ
CompletableFuture<Void> allAnalyses = CompletableFuture.allOf(
statisticalAnalysis, correlationAnalysis, outlierDetection
);

allAnalyses.join();  // ਪੂਰੇ ਹੋਣ ਦੀ ਉਡੀਕ ਕਰੋ

// ਕਦਮ 3: ਨਤੀਜੇ ਜੋੜੋ
Map<String, Object> combinedResults = new HashMap<>();
combinedResults.put("metadata", metadataResponse.getResult());
combinedResults.put("statistics", statisticalAnalysis.join().getResult());
combinedResults.put("correlations", correlationAnalysis.join().getResult());
combinedResults.put("outliers", outlierDetection.join().getResult());

// ਕਦਮ 4: ਸੰਖੇਪ ਰਿਪੋਰਟ ਬਣਾਓ
ToolResponse summaryResponse = mcpClient.executeTool("reportGenerator",
Map.of("analysisResults", combinedResults));

// ਪੂਰੇ ਵਰਕਫਲੋ ਨਤੀਜੇ ਵਾਪਸ ਕਰੋ
WorkflowResult result = new WorkflowResult();
result.setDatasetId(datasetId);
result.setAnalysisResults(combinedResults);
result.setSummaryReport(summaryResponse.getResult());

return result;
}
}
```

### 4. Error Recovery Pattern

Implement graceful fallbacks for tool failures:

```python
class ResilientWorkflow:
def __init__(self, mcp_client):
self.client = mcp_client

async def execute_with_fallback(self, primary_tool, fallback_tool, parameters):
try:
# ਪਹਿਲਾਂ ਪ੍ਰਾਇਮਰੀ ਟੂਲ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰੋ
response = await self.client.execute_tool(primary_tool, parameters)
return {
"result": response.result,
"source": "primary",
"tool": primary_tool
}
except ToolExecutionException as e:
# ਅਸਫਲਤਾ ਨੂੰ ਲੌਗ ਕਰੋ
logging.warning(f"Primary tool '{primary_tool}' failed: {str(e)}")

# ਸੈਕੰਡਰੀ ਟੂਲ ਤੇ ਜਾਓ
try:
# fallback ਟੂਲ ਲਈ ਪੈਰਾਮੀਟਰ ਬਦਲਣ ਦੀ ਲੋੜ ਹੋ ਸਕਦੀ ਹੈ
fallback_params = self._adapt_parameters(parameters, primary_tool, fallback_tool)

response = await self.client.execute_tool(fallback_tool, fallback_params)
return {
"result": response.result,
"source": "fallback",
"tool": fallback_tool,
"primaryError": str(e)
}
except ToolExecutionException as fallback_error:
# ਦੋਹਾਂ ਟੂਲਾਂ ਨੇ ਅਸਫਲਤਾ ਦਿੱਤੀ
logging.error(f"Both primary and fallback tools failed. Fallback error: {str(fallback_error)}")
raise WorkflowExecutionException(
f"Workflow failed: primary error: {str(e)}; fallback error: {str(fallback_error)}"
)

def _adapt_parameters(self, params, from_tool, to_tool):
"""ਜੇ ਲੋੜ ਹੋਵੇ ਤਾਂ ਵੱਖ-ਵੱਖ ਟੂਲਾਂ ਲਈ ਪੈਰਾਮੀਟਰ ਅਨੁਕੂਲਿਤ ਕਰੋ"""
# ਇਹ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਖਾਸ ਟੂਲਾਂ 'ਤੇ ਨਿਰਭਰ ਕਰੇਗੀ
# ਇਸ ਉਦਾਹਰਨ ਲਈ, ਅਸੀਂ ਸਿਰਫ ਮੂਲ ਪੈਰਾਮੀਟਰ ਵਾਪਸ ਕਰਾਂਗੇ
return params

# ਉਦਾਹਰਨ ਵਰਤੋਂ
async def get_weather(workflow, location):
return await workflow.execute_with_fallback(
"premiumWeatherService",  # ਪ੍ਰਾਇਮਰੀ (ਪੇਡ) ਮੌਸਮ API
"basicWeatherService",    # fallback (ਮੁਫ਼ਤ) ਮੌਸਮ API
{"location": location}
)
```

### 5. Workflow Composition Pattern

Build complex workflows by composing simpler ones:

```csharp
public class CompositeWorkflow : IWorkflow
{
private readonly List<IWorkflow> _workflows;

public CompositeWorkflow(IEnumerable<IWorkflow> workflows)
{
_workflows = new List<IWorkflow>(workflows);
}

public async Task<WorkflowResult> ExecuteAsync(WorkflowContext context)
{
var results = new Dictionary<string, object>();

foreach (var workflow in _workflows)
{
var workflowResult = await workflow.ExecuteAsync(context);

// ਹਰ ਵਰਕਫਲੋ ਦਾ ਨਤੀਜਾ ਸਟੋਰ ਕਰੋ
results[workflow.Name] = workflowResult;

// ਅਗਲੇ ਵਰਕਫਲੋ ਲਈ ਸੰਦਰਭ ਨੂੰ ਨਤੀਜੇ ਨਾਲ ਅਪਡੇਟ ਕਰੋ
context = context.WithResult(workflow.Name, workflowResult);
}

return new WorkflowResult(results);
}

public string Name => "CompositeWorkflow";
public string Description => "ਕਈ ਵਰਕਫਲੋਜ਼ ਨੂੰ ਲੜੀਵਾਰ ਚਲਾਉਂਦਾ ਹੈ";
}

// ਉਦਾਹਰਨ ਵਰਤੋਂ
var documentWorkflow = new CompositeWorkflow(new IWorkflow[] {
new DocumentFetchWorkflow(),
new DocumentProcessingWorkflow(),
new InsightGenerationWorkflow(),
new ReportGenerationWorkflow()
});

var result = await documentWorkflow.ExecuteAsync(new WorkflowContext {
Parameters = new { documentId = "12345" }
});
```

# Testing MCP Servers: Best Practices and Top Tips

## Overview

Testing is a critical aspect of developing reliable, high-quality MCP servers. This guide provides comprehensive best practices and tips for testing your MCP servers throughout the development lifecycle, from unit tests to integration tests and end-to-end validation.

## Why Testing Matters for MCP Servers

MCP servers serve as crucial middleware between AI models and client applications. Thorough testing ensures:

- Reliability in production environments
- Accurate handling of requests and responses
- Proper implementation of MCP specifications
- Resilience against failures and edge cases
- Consistent performance under various loads

## Unit Testing for MCP Servers

### Unit Testing (Foundation)

Unit tests verify individual components of your MCP server in isolation.

#### What to Test

1. **Resource Handlers**: Test each resource handler's logic independently
2. **Tool Implementations**: Verify tool behavior with various inputs
3. **Prompt Templates**: Ensure prompt templates render correctly
4. **Schema Validation**: Test parameter validation logic
5. **Error Handling**: Verify error responses for invalid inputs

#### Best Practices for Unit Testing

```csharp
// C# ਵਿੱਚ ਕੈਲਕੁਲੇਟਰ ਟੂਲ ਲਈ ਉਦਾਹਰਨ ਯੂਨਿਟ ਟੈਸਟ
[Fact]
public async Task CalculatorTool_Add_ReturnsCorrectSum()
{
// ਤਿਆਰੀ
var calculator = new CalculatorTool();
var parameters = new Dictionary<string, object>
{
["operation"] = "add",
["a"] = 5,
["b"] = 7
};

// ਕਾਰਵਾਈ
var response = await calculator.ExecuteAsync(parameters);
var result = JsonSerializer.Deserialize<CalculationResult>(response.Content[0].ToString());

// ਪੁਸ਼ਟੀ
Assert.Equal(12, result.Value);
}
```

```python
# Python ਵਿੱਚ ਕੈਲਕੁਲੇਟਰ ਟੂਲ ਲਈ ਉਦਾਹਰਨ ਯੂਨਿਟ ਟੈਸਟ
def test_calculator_tool_add():
# ਤਿਆਰੀ
calculator = CalculatorTool()
parameters = {
"operation": "add",
"a": 5,
"b": 7
}

# ਕਾਰਵਾਈ
response = calculator.execute(parameters)
result = json.loads(response.content[0].text)

# ਪੁਸ਼ਟੀ
assert result["value"] == 12
```

### Integration Testing (Middle Layer)

Integration tests verify interactions between components of your MCP server.

#### What to Test

1. **Server Initialization**: Test server startup with various configurations
2. **Route Registration**: Verify all endpoints are correctly registered
3. **Request Processing**: Test the full request-response cycle
4. **Error Propagation**: Ensure errors are properly handled across components
5. **Authentication & Authorization**: Test security mechanisms

#### Best Practices for Integration Testing

```csharp
// C# ਵਿੱਚ MCP ਸਰਵਰ ਲਈ ਉਦਾਹਰਨ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਟੈਸਟ
[Fact]
public async Task Server_ProcessToolRequest_ReturnsValidResponse()
{
// ਤਿਆਰੀ
var server = new McpServer();
server.RegisterTool(new CalculatorTool());
await server.StartAsync();

var request = new McpRequest
{
Tool = "calculator",
Parameters = new Dictionary<string, object>
{
["operation"] = "multiply",
["a"] = 6,
["b"] = 7
}
};

// ਕਾਰਵਾਈ
var response = await server.ProcessRequestAsync(request);

// ਪੁਸ਼ਟੀ
Assert.NotNull(response);
Assert.Equal(McpStatusCodes.Success, response.StatusCode);
// ਜਵਾਬ ਸਮੱਗਰੀ ਲਈ ਵਾਧੂ ਪੁਸ਼ਟੀਆਂ

// ਸਾਫ਼-ਸਫਾਈ
await server.StopAsync();
}
```

### End-to-End Testing (Top Layer)

End-to-end tests verify the complete system behavior from client to server.

#### What to Test

1. **Client-Server Communication**: Test complete request-response cycles
2. **Real Client SDKs**: Test with actual client implementations
3. **Performance Under Load**: Verify behavior with multiple concurrent requests
4. **Error Recovery**: Test system recovery from failures
5. **Long-Running Operations**: Verify handling of streaming and long operations

#### Best Practices for E2E Testing

```typescript
// TypeScript ਵਿੱਚ ਕਲਾਇੰਟ ਨਾਲ E2E ਟੈਸਟ ਦੀ ਉਦਾਹਰਨ
describe('MCP Server E2E Tests', () => {
let client: McpClient;

beforeAll(async () => {
// ਟੈਸਟ ਵਾਤਾਵਰਣ ਵਿੱਚ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ
await startTestServer();
client = new McpClient('http://localhost:5000');
});

afterAll(async () => {
await stopTestServer();
});

test('Client can invoke calculator tool and get correct result', async () => {
// ਕਾਰਵਾਈ
const response = await client.invokeToolAsync('calculator', {
operation: 'divide',
a: 20,
b: 4
});

// ਪੁਸ਼ਟੀ
expect(response.statusCode).toBe(200);
expect(response.content[0].text).toContain('5');
});
});
```

## Mocking Strategies for MCP Testing

Mocking is essential for isolating components during testing.

### Components to Mock

1. **External AI Models**: Mock model responses for predictable testing
2. **External Services**: Mock API dependencies (databases, third-party services)
3. **Authentication Services**: Mock identity providers
4. **Resource Providers**: Mock expensive resource handlers

### Example: Mocking an AI Model Response

```csharp
// C# ਵਿੱਚ Moq ਨਾਲ ਉਦਾਹਰਨ
var mockModel = new Mock<ILanguageModel>();
mockModel
.Setup(m => m.GenerateResponseAsync(
It.IsAny<string>(),
It.IsAny<McpRequestContext>()))
.ReturnsAsync(new ModelResponse {
Text = "Mocked model response",
FinishReason = FinishReason.Completed
});

var server = new McpServer(modelClient: mockModel.Object);
```

```python
# Python ਵਿੱਚ unittest.mock ਨਾਲ ਉਦਾਹਰਨ
@patch('mcp_server.models.OpenAIModel')
def test_with_mock_model(mock_model):
# ਮੌਕ ਸੈੱਟ ਕਰੋ
mock_model.return_value.generate_response.return_value = {
"text": "Mocked model response",
"finish_reason": "completed"
}

# ਟੈਸਟ ਵਿੱਚ ਮੌਕ ਦੀ ਵਰਤੋਂ ਕਰੋ
server = McpServer(model_client=mock_model)
# ਟੈਸਟ ਜਾਰੀ ਰੱਖੋ
```

## Performance Testing

Performance testing is crucial for production MCP servers.

### What to Measure

1. **Latency**: Response time for requests
2. **Throughput**: Requests handled per second
3. **Resource Utilization**: CPU, memory, network usage
4. **Concurrency Handling**: Behavior under parallel requests
5. **Scaling Characteristics**: Performance as load increases

### Tools for Performance Testing

- **k6**: Open-source load testing tool
- **JMeter**: Comprehensive performance testing
- **Locust**: Python-based load testing
- **Azure Load Testing**: Cloud-based performance testing

### Example: Basic Load Test with k6

```javascript
// MCP ਸਰਵਰ ਲਈ k6 ਲੋਡ ਟੈਸਟ ਸਕ੍ਰਿਪਟ
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
vus: 10,  // 10 ਵਰਚੁਅਲ ਯੂਜ਼ਰ
duration: '30s',
};

export default function () {
const payload = JSON.stringify({
tool: 'calculator',
parameters: {
operation: 'add',
a: Math.floor(Math.random() * 100),
b: Math.floor(Math.random() * 100)
}
});

const params = {
headers: {
'Content-Type': 'application/json',
'Authorization': 'Bearer test-token'
},
};

const res = http.post('http://localhost:5000/api/tools/invoke', payload, params);

check(res, {
'status is 200': (r) => r.status === 200,
'response time < 500ms': (r) => r.timings.duration < 500,
});

sleep(1);
}
```

## Test Automation for MCP Servers

Automating your tests ensures consistent quality and faster feedback loops.

### CI/CD Integration

1. **Run Unit Tests on Pull Requests**: Ensure code changes don't break existing functionality
2. **Integration Tests in Staging**: Run integration tests in pre-production environments
3. **Performance Baselines**: Maintain performance benchmarks to catch regressions
4. **Security Scans**: Automate security testing as part of the pipeline

### Example CI Pipeline (GitHub Actions)

```yaml
name: MCP Server Tests

on:
push:
branches: [ main ]
pull_request:
branches: [ main ]

jobs:
test:
runs-on: ubuntu-latest

steps:
- uses: actions/checkout@v2

- name: Set up Runtime
uses: actions/setup-dotnet@v1
with:
dotnet-version: '8.0.x'

- name: Restore dependencies
run: dotnet restore

- name: Build
run: dotnet build --no-restore

- name: Unit Tests
run: dotnet test --no-build --filter Category=Unit

- name: Integration Tests
run: dotnet test --no-build --filter Category=Integration

- name: Performance Tests
run: dotnet run --project tests/PerformanceTests/PerformanceTests.csproj
```

## Testing for Compliance with MCP Specification

Verify your server correctly implements the MCP specification.

### Key Compliance Areas

1. **API Endpoints**: Test required endpoints (/resources, /tools, etc.)
2. **Request/Response Format**: Validate schema compliance
3. **Error Codes**: Verify correct status codes for various scenarios
4. **Content Types**: Test handling of different content types
5. **Authentication Flow**: Verify spec-compliant auth mechanisms

### Compliance Test Suite

```csharp
[Fact]
public async Task Server_ResourceEndpoint_ReturnsCorrectSchema()
{
// ਤਿਆਰੀ
var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", "Bearer test-token");

// ਕਾਰਵਾਈ
var response = await client.GetAsync("http://localhost:5000/api/resources");
var content = await response.Content.ReadAsStringAsync();
var resources = JsonSerializer.Deserialize

// Assert
Assert.Equal(HttpStatusCode.OK, response.StatusCode);
Assert.NotNull(resources);
Assert.All(resources.Resources, resource => 
{
    Assert.NotNull(resource.Id);
    Assert.NotNull(resource.Type);
    // ਵਾਧੂ ਸਕੀਮਾ ਵੈਰੀਫਿਕੇਸ਼ਨ
});
}

## ਪ੍ਰਭਾਵਸ਼ਾਲੀ MCP ਸਰਵਰ ਟੈਸਟਿੰਗ ਲਈ ਸਿਖਰਲੇ 10 ਸੁਝਾਅ

1. **ਟੈਸਟ ਟੂਲ ਪਰਿਭਾਸ਼ਾਵਾਂ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟ ਕਰੋ**: ਟੂਲ ਲਾਜਿਕ ਤੋਂ ਵੱਖਰੇ ਸਕੀਮਾ ਪਰਿਭਾਸ਼ਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰੋ  
2. **ਪੈਰਾਮੀਟਰਾਈਜ਼ਡ ਟੈਸਟ ਵਰਤੋ**: ਵੱਖ-ਵੱਖ ਇਨਪੁੱਟਸ ਸਮੇਤ ਐਜ ਕੇਸਾਂ ਨਾਲ ਟੂਲਾਂ ਦੀ ਜਾਂਚ ਕਰੋ  
3. **ਗਲਤੀ ਜਵਾਬਾਂ ਦੀ ਜਾਂਚ ਕਰੋ**: ਸਾਰੇ ਸੰਭਾਵਿਤ ਗਲਤੀ ਹਾਲਾਤਾਂ ਲਈ ਠੀਕ ਗਲਤੀ ਸੰਭਾਲ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ  
4. **ਅਧਿਕਾਰ ਲਾਜਿਕ ਦੀ ਜਾਂਚ ਕਰੋ**: ਵੱਖ-ਵੱਖ ਯੂਜ਼ਰ ਭੂਮਿਕਾਵਾਂ ਲਈ ਸਹੀ ਐਕਸੈਸ ਕੰਟਰੋਲ ਯਕੀਨੀ ਬਣਾਓ  
5. **ਟੈਸਟ ਕਵਰੇਜ ਦੀ ਨਿਗਰਾਨੀ ਕਰੋ**: ਅਹੰਕਾਰਪੂਰਨ ਕੋਡ ਪਾਥ ਦੀ ਉੱਚ ਕਵਰੇਜ ਦਾ ਲਕੜੀ ਰੱਖੋ  
6. **ਸਟ੍ਰੀਮਿੰਗ ਜਵਾਬਾਂ ਦੀ ਟੈਸਟਿੰਗ ਕਰੋ**: ਸਟ੍ਰੀਮਿੰਗ ਸਮੱਗਰੀ ਦੀ ਠੀਕ ਸੰਭਾਲ ਦੀ ਜਾਂਚ ਕਰੋ  
7. **ਨੈੱਟਵਰਕ ਸਮੱਸਿਆਵਾਂ ਦਾ ਅਨੁਕਰਨ ਕਰੋ**: ਖਰਾਬ ਨੈੱਟਵਰਕ ਹਾਲਾਤਾਂ ਵਿੱਚ ਵਿਹਾਰ ਦੀ ਟੈਸਟਿੰਗ ਕਰੋ  
8. **ਸੰਸਾਧਨ ਸੀਮਾਵਾਂ ਦੀ ਜਾਂਚ ਕਰੋ**: ਕੋਟਾ ਜਾਂ ਰੇਟ ਲਿਮਿਟ ਪਹੁੰਚਣ 'ਤੇ ਵਿਹਾਰ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ  
9. **ਰੀਗ੍ਰੈਸ਼ਨ ਟੈਸਟਾਂ ਨੂੰ ਆਟੋਮੇਟ ਕਰੋ**: ਹਰ ਕੋਡ ਬਦਲਾਅ 'ਤੇ ਚੱਲਣ ਵਾਲੀ ਟੈਸਟ ਸੂਟ ਬਣਾਓ  
10. **ਟੈਸਟ ਕੇਸਾਂ ਦਾ ਦਸਤਾਵੇਜ਼ ਬਣਾਓ**: ਟੈਸਟ ਸਿਨਾਰਿਓਜ਼ ਦੀ ਸਾਫ਼-ਸੁਥਰੀ ਦਸਤਾਵੇਜ਼ੀਕਰਨ ਰੱਖੋ  

## ਆਮ ਟੈਸਟਿੰਗ ਦੀਆਂ ਗਲਤੀਆਂ

- **ਸਿਰਫ ਖੁਸ਼ਹਾਲ ਰਾਹ ਦੀ ਟੈਸਟਿੰਗ 'ਤੇ ਜ਼ਿਆਦਾ ਨਿਰਭਰਤਾ**: ਗਲਤੀ ਹਾਲਾਤਾਂ ਦੀ ਪੂਰੀ ਤਰ੍ਹਾਂ ਜਾਂਚ ਕਰੋ  
- **ਪ੍ਰਦਰਸ਼ਨ ਟੈਸਟਿੰਗ ਨੂੰ ਨਜ਼ਰਅੰਦਾਜ਼ ਕਰਨਾ**: ਉਤਪਾਦਨ 'ਤੇ ਪ੍ਰਭਾਵ ਪਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਬੋਤਲਨੈਕ ਦੀ ਪਹਚਾਣ ਕਰੋ  
- **ਸਿਰਫ ਅਲੱਗ-ਅਲੱਗ ਟੈਸਟਿੰਗ**: ਯੂਨਿਟ, ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਅਤੇ E2E ਟੈਸਟਾਂ ਨੂੰ ਮਿਲਾ ਕੇ ਚਲਾਓ  
- **ਅਧੂਰੀ API ਕਵਰੇਜ**: ਸਾਰੇ ਐਂਡਪੌਇੰਟ ਅਤੇ ਫੀਚਰਾਂ ਦੀ ਟੈਸਟਿੰਗ ਯਕੀਨੀ ਬਣਾਓ  
- **ਅਸਥਿਰ ਟੈਸਟ ਵਾਤਾਵਰਣ**: ਸਥਿਰ ਟੈਸਟ ਵਾਤਾਵਰਣ ਲਈ ਕੰਟੇਨਰ ਵਰਤੋ  

## ਨਤੀਜਾ

ਇੱਕ ਵਿਸਤ੍ਰਿਤ ਟੈਸਟਿੰਗ ਰਣਨੀਤੀ ਭਰੋਸੇਮੰਦ, ਉੱਚ-ਗੁਣਵੱਤਾ ਵਾਲੇ MCP ਸਰਵਰਾਂ ਦੇ ਵਿਕਾਸ ਲਈ ਜ਼ਰੂਰੀ ਹੈ। ਇਸ ਗਾਈਡ ਵਿੱਚ ਦਿੱਤੇ ਸਭ ਤੋਂ ਵਧੀਆ ਅਭਿਆਸਾਂ ਅਤੇ ਸੁਝਾਅ ਨੂੰ ਲਾਗੂ ਕਰਕੇ, ਤੁਸੀਂ ਯਕੀਨੀ ਬਣਾ ਸਕਦੇ ਹੋ ਕਿ ਤੁਹਾਡੇ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਉੱਚਤਮ ਗੁਣਵੱਤਾ, ਭਰੋਸੇਯੋਗਤਾ ਅਤੇ ਪ੍ਰਦਰਸ਼ਨ ਦੇ ਮਿਆਰਾਂ 'ਤੇ ਖਰੇ ਉਤਰਦੇ ਹਨ।  

## ਮੁੱਖ ਸਿੱਖਣ ਵਾਲੀਆਂ ਗੱਲਾਂ

1. **ਟੂਲ ਡਿਜ਼ਾਈਨ**: ਸਿੰਗਲ ਜ਼ਿੰਮੇਵਾਰੀ ਸਿਧਾਂਤ ਦੀ ਪਾਲਣਾ ਕਰੋ, ਡਿਪੈਂਡੈਂਸੀ ਇੰਜੈਕਸ਼ਨ ਵਰਤੋ, ਅਤੇ ਕੰਪੋਜ਼ੇਬਿਲਟੀ ਲਈ ਡਿਜ਼ਾਈਨ ਕਰੋ  
2. **ਸਕੀਮਾ ਡਿਜ਼ਾਈਨ**: ਸਾਫ਼, ਚੰਗੀ ਤਰ੍ਹਾਂ ਦਸਤਾਵੇਜ਼ਬੱਧ ਸਕੀਮਾਂ ਬਣਾਓ ਜਿਨ੍ਹਾਂ ਵਿੱਚ ਠੀਕ ਵੈਧਤਾ ਸੀਮਾਵਾਂ ਹੋਣ  
3. **ਗਲਤੀ ਸੰਭਾਲ**: ਸੁਚੱਜੀ ਗਲਤੀ ਸੰਭਾਲ, ਸੰਰਚਿਤ ਗਲਤੀ ਜਵਾਬ ਅਤੇ ਰੀਟ੍ਰਾਈ ਲਾਜਿਕ ਲਾਗੂ ਕਰੋ  
4. **ਪ੍ਰਦਰਸ਼ਨ**: ਕੈਸ਼ਿੰਗ, ਅਸਿੰਕ੍ਰੋਨਸ ਪ੍ਰੋਸੈਸਿੰਗ ਅਤੇ ਸੰਸਾਧਨ ਸੀਮਿਤ ਕਰਨ ਦੀ ਵਰਤੋਂ ਕਰੋ  
5. **ਸੁਰੱਖਿਆ**: ਪੂਰੀ ਇਨਪੁੱਟ ਵੈਧਤਾ, ਅਧਿਕਾਰ ਜਾਂਚ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਸੰਭਾਲ ਲਾਗੂ ਕਰੋ  
6. **ਟੈਸਟਿੰਗ**: ਵਿਸਤ੍ਰਿਤ ਯੂਨਿਟ, ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਅਤੇ ਐਂਡ-ਟੂ-ਐਂਡ ਟੈਸਟ ਬਣਾਓ  
7. **ਵਰਕਫਲੋ ਪੈਟਰਨ**: ਸਥਾਪਿਤ ਪੈਟਰਨ ਜਿਵੇਂ ਕਿ ਚੇਨਜ਼, ਡਿਸਪੈਚਰ ਅਤੇ ਪੈਰਲੇਲ ਪ੍ਰੋਸੈਸਿੰਗ ਲਾਗੂ ਕਰੋ  

## ਅਭਿਆਸ

ਇੱਕ ਦਸਤਾਵੇਜ਼ ਪ੍ਰੋਸੈਸਿੰਗ ਸਿਸਟਮ ਲਈ MCP ਟੂਲ ਅਤੇ ਵਰਕਫਲੋ ਡਿਜ਼ਾਈਨ ਕਰੋ ਜੋ:

1. ਕਈ ਫਾਰਮੈਟਾਂ (PDF, DOCX, TXT) ਵਿੱਚ ਦਸਤਾਵੇਜ਼ ਸਵੀਕਾਰ ਕਰਦਾ ਹੈ  
2. ਦਸਤਾਵੇਜ਼ਾਂ ਵਿੱਚੋਂ ਟੈਕਸਟ ਅਤੇ ਮੁੱਖ ਜਾਣਕਾਰੀ ਕੱਢਦਾ ਹੈ  
3. ਦਸਤਾਵੇਜ਼ਾਂ ਨੂੰ ਕਿਸਮ ਅਤੇ ਸਮੱਗਰੀ ਅਨੁਸਾਰ ਵਰਗੀਕ੍ਰਿਤ ਕਰਦਾ ਹੈ  
4. ਹਰ ਦਸਤਾਵੇਜ਼ ਦਾ ਸਾਰ ਸੰਪਾਦਿਤ ਕਰਦਾ ਹੈ  

ਇਸ ਸਿਨਾਰਿਓ ਲਈ ਸਭ ਤੋਂ ਵਧੀਆ ਟੂਲ ਸਕੀਮਾਂ, ਗਲਤੀ ਸੰਭਾਲ ਅਤੇ ਵਰਕਫਲੋ ਪੈਟਰਨ ਲਾਗੂ ਕਰੋ। ਸੋਚੋ ਕਿ ਤੁਸੀਂ ਇਸ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਦੀ ਟੈਸਟਿੰਗ ਕਿਵੇਂ ਕਰੋਗੇ।  

## ਸਰੋਤ

1. MCP ਕਮਿਊਨਿਟੀ ਨਾਲ ਜੁੜੋ [Azure AI Foundry Discord Community](https://aka.ms/foundrydevs) 'ਤੇ ਤਾਜ਼ਾ ਵਿਕਾਸਾਂ ਲਈ  
2. ਖੁੱਲ੍ਹੇ ਸਰੋਤ [MCP ਪ੍ਰੋਜੈਕਟਾਂ](https://github.com/modelcontextprotocol) ਵਿੱਚ ਯੋਗਦਾਨ ਪਾਓ  
3. ਆਪਣੀ ਸੰਸਥਾ ਦੀ AI ਪਹਿਲਕਦਮੀਆਂ ਵਿੱਚ MCP ਸਿਧਾਂਤ ਲਾਗੂ ਕਰੋ  
4. ਆਪਣੇ ਉਦਯੋਗ ਲਈ ਵਿਸ਼ੇਸ਼ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨਾਂ ਦੀ ਖੋਜ ਕਰੋ  
5. ਖਾਸ MCP ਵਿਸ਼ਿਆਂ 'ਤੇ ਉੱਚ-ਸਤਹ ਕੋਰਸਾਂ ਬਾਰੇ ਸੋਚੋ, ਜਿਵੇਂ ਕਿ ਮਲਟੀ-ਮੋਡਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਜਾਂ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਐਪਲੀਕੇਸ਼ਨ ਇੰਟੀਗ੍ਰੇਸ਼ਨ  
6. [Hands on Lab](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) ਰਾਹੀਂ ਸਿੱਖੇ ਗਏ ਸਿਧਾਂਤਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ MCP ਟੂਲ ਅਤੇ ਵਰਕਫਲੋ ਬਣਾਉਣ ਦਾ ਅਭਿਆਸ ਕਰੋ  

ਅਗਲਾ: ਬਿਹਤਰ ਅਭਿਆਸ [ਕੇਸ ਅਧਿਐਨ](../09-CaseStudy/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।