<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8f12fc94cee9ed16a5eddf9f51fba755",
  "translation_date": "2025-05-17T14:53:59+00:00",
  "source_file": "04-PracticalImplementation/samples/javascript/README.md",
  "language_code": "sr"
}
-->
# Пример

Ово је пример JavaScript-а за MCP сервер

Ево примера регистрације алата где региструјемо алат који прави лажни позив LLM-у:

```javascript
this.mcpServer.tool(
    'completion',
    {
    model: z.string(),
    prompt: z.string(),
    options: z.object({
        temperature: z.number().optional(),
        max_tokens: z.number().optional(),
        stream: z.boolean().optional()
    }).optional()
    },
    async ({ model, prompt, options }) => {
    console.log(`Processing completion request for model: ${model}`);
    
    // Validate model
    if (!this.models.includes(model)) {
        throw new Error(`Model ${model} not supported`);
    }
    
    // Emit event for monitoring/metrics
    this.events.emit('request', { 
        type: 'completion', 
        model, 
        timestamp: new Date() 
    });
    
    // In a real implementation, this would call an AI model
    // Here we just echo back parts of the request with a mock response
    const response = {
        id: `mcp-resp-${Date.now()}`,
        model,
        text: `This is a response to: ${prompt.substring(0, 30)}...`,
        usage: {
        promptTokens: prompt.split(' ').length,
        completionTokens: 20,
        totalTokens: prompt.split(' ').length + 20
        }
    };
    
    // Simulate network delay
    await new Promise(resolve => setTimeout(resolve, 500));
    
    // Emit completion event
    this.events.emit('completion', {
        model,
        timestamp: new Date()
    });
    
    return {
        content: [
        {
            type: 'text',
            text: JSON.stringify(response)
        }
        ]
    };
    }
);
```

## Инсталација

Покрените следећу команду:

```bash
npm install
```

## Покретање

```bash
npm start
```

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo da postignemo tačnost, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proisteknu iz korišćenja ovog prevoda.