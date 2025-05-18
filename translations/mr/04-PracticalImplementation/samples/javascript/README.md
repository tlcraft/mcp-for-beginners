<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8f12fc94cee9ed16a5eddf9f51fba755",
  "translation_date": "2025-05-17T14:49:06+00:00",
  "source_file": "04-PracticalImplementation/samples/javascript/README.md",
  "language_code": "mr"
}
-->
# नमुना

हे MCP सर्व्हरसाठी JavaScript नमुना आहे

येथे साधन नोंदणीचे उदाहरण आहे जिथे आपण LLM ला नकली कॉल करणारे साधन नोंदवतो:

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

## इंस्टॉल करा

खालील कमांड चालवा:

```bash
npm install
```

## चालवा

```bash
npm start
```

**अस्वीकृती**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरात त्रुटी किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकारिक स्रोत म्हणून विचारात घेतला पाहिजे. महत्त्वाच्या माहितीकरिता, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.