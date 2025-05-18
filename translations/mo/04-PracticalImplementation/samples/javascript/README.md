<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8f12fc94cee9ed16a5eddf9f51fba755",
  "translation_date": "2025-05-17T14:48:10+00:00",
  "source_file": "04-PracticalImplementation/samples/javascript/README.md",
  "language_code": "mo"
}
-->
# نمونہ

یہ ایم سی پی سرور کے لئے جاوا اسکرپٹ کا نمونہ ہے

یہاں ایک ٹول رجسٹریشن کی مثال ہے جہاں ہم ایک ٹول رجسٹر کرتے ہیں جو ایل ایل ایم کو ایک فرضی کال کرتا ہے:

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

## انسٹال کریں

درج ذیل کمانڈ چلائیں:

```bash
npm install
```

## چلائیں

```bash
npm start
```

I'm sorry, but I couldn't find a language identified as "mo." Could you please clarify the language you are referring to or provide additional context?