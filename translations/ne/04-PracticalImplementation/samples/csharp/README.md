<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:48:51+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "ne"
}
-->
# नमूना

अघिल्लो उदाहरणले देखाउँछ कसरी स्थानीय .NET परियोजना `stdio` प्रकारसँग प्रयोग गर्ने। र कसरी कन्टेनरमा सर्भरलाई स्थानीय रूपमा चलाउने। धेरै अवस्थामा यो राम्रो समाधान हो। तर सर्भरलाई क्लाउड वातावरण जस्ता रिमोट स्थानमा चलाउनु पनि उपयोगी हुन सक्छ। त्यहीँ `http` प्रकार काम लाग्छ।

`04-PracticalImplementation` फोल्डरमा समाधान हेर्दा यो अघिल्लो भन्दा धेरै जटिल देखिन सक्छ। तर वास्तविकतामा त्यस्तो छैन। परियोजना `src/Calculator` नजिकबाट हेर्दा, तपाईं देख्नुहुनेछ कि यो अधिकांशतः अघिल्लो उदाहरणकै जस्तै कोड हो। फरक केवल यति छ कि हामी HTTP अनुरोधहरू व्यवस्थापन गर्न भिन्न पुस्तकालय `ModelContextProtocol.AspNetCore` प्रयोग गर्दैछौं। र हामी मेथड `IsPrime` लाई निजी बनाउँछौं, केवल देखाउनका लागि कि तपाईंको कोडमा निजी मेथडहरू पनि हुन सक्छन्। बाँकी कोड अघिल्लो जस्तै छ।

अन्य परियोजनाहरू [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview) बाट छन्। समाधानमा .NET Aspire हुनु विकासकर्ता अनुभव सुधार गर्छ विकास र परीक्षणको क्रममा र अवलोकनमा मद्दत गर्छ। सर्भर चलाउन आवश्यक छैन, तर समाधानमा राख्नु राम्रो अभ्यास हो।

## सर्भर स्थानीय रूपमा सुरु गर्नुहोस्

1. VS Code (C# DevKit एक्सटेन्सनसहित) बाट `04-PracticalImplementation/samples/csharp` डाइरेक्टरीमा जानुहोस्।
1. सर्भर सुरु गर्न निम्न कमाण्ड चलाउनुहोस्:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. जब वेब ब्राउजरले .NET Aspire ड्यासबोर्ड खोल्छ, `http` URL नोट गर्नुहोस्। यो यस्तो हुनुपर्छ: `http://localhost:5058/`।

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.ne.png)

## MCP Inspector सँग Streamable HTTP परीक्षण गर्नुहोस्

यदि तपाईं सँग Node.js 22.7.5 वा माथि छ भने, तपाईं MCP Inspector प्रयोग गरेर सर्भर परीक्षण गर्न सक्नुहुन्छ।

सर्भर सुरु गर्नुहोस् र टर्मिनलमा तलको कमाण्ड चलाउनुहोस्:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.ne.png)

- `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp` चयन गर्नुहोस्। यो `http` हुनुपर्छ (`https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` होइन) जुन पहिले सिर्जना गरिएको सर्भर जस्तो देखिन्छ:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

केही परीक्षणहरू गर्नुहोस्:

- "6780 पछि 3 प्राथमिक संख्या" सोध्नुहोस्। हेर्नुहोस् Copilot नयाँ उपकरण `NextFivePrimeNumbers` प्रयोग गरेर केवल पहिलो 3 प्राथमिक संख्या फर्काउँछ।
- "111 पछि 7 प्राथमिक संख्या" सोध्नुहोस् र के हुन्छ हेर्नुहोस्।
- "जोनसँग २४ लल्लीहरू छन् र उनी आफ्ना ३ बच्चाहरूलाई सबै बाँड्न चाहन्छ। प्रत्येक बच्चाले कति लल्ली पाउँछ?" सोध्नुहोस् र के हुन्छ हेर्नुहोस्।

## सर्भर Azure मा डिप्लोय गर्नुहोस्

सर्भरलाई Azure मा डिप्लोय गरौं ताकि धेरै मानिसहरूले प्रयोग गर्न सकून्।

टर्मिनलबाट `04-PracticalImplementation/samples/csharp` फोल्डरमा जानुहोस् र निम्न कमाण्ड चलाउनुहोस्:

```bash
azd up
```

डिप्लोयमेन्ट सकिएपछि, तपाईंलाई यस्तो सन्देश देखिनु पर्छ:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.ne.png)

URL लिएर MCP Inspector र GitHub Copilot Chat मा प्रयोग गर्नुहोस्।

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## अब के गर्ने?

हामी विभिन्न ट्रान्सपोर्ट प्रकार र परीक्षण उपकरणहरू प्रयास गर्छौं। हामी तपाईंको MCP सर्भर Azure मा पनि डिप्लोय गर्छौं। तर यदि हाम्रो सर्भरले निजी स्रोतहरू पहुँच गर्नुपर्ने भए? उदाहरणका लागि, डेटाबेस वा निजी API? अर्को अध्यायमा हामी हेरौं कसरी सर्भरको सुरक्षा सुधार गर्न सकिन्छ।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको हो। हामी सटीकताको लागि प्रयासरत छौं भने पनि, कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलतफहमी हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै आधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलत बुझाइ वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।