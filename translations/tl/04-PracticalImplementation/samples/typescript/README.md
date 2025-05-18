<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f7a8ffd07682d554929968dfc6ae2ecb",
  "translation_date": "2025-05-17T15:06:32+00:00",
  "source_file": "04-PracticalImplementation/samples/typescript/README.md",
  "language_code": "tl"
}
-->
# Halimbawa

Ito ay isang halimbawa ng Typescript para sa isang MCP Server

Narito ang isang halimbawa ng paglikha ng tool:

```typescript
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

## I-install

Patakbuhin ang sumusunod na utos:

```bash
npm install
```

## Patakbuhin

```bash
npm start
```

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI na serbisyo sa pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat sinisikap naming maging tumpak, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi pagiging tama. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.