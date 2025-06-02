<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:53:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "ne"
}
-->
## Distributed Architecture

Distributed architecture मा धेरै MCP नोडहरू सँगै काम गर्छन् जसले अनुरोधहरू ह्यान्डल गर्छन्, स्रोतहरू साझा गर्छन्, र redundancy प्रदान गर्छन्। यसले scalability र fault tolerance लाई बढावा दिन्छ किनभने नोडहरू distributed system मार्फत संवाद र समन्वय गर्न सक्छन्।

Redis प्रयोग गरेर coordination को लागि distributed MCP server architecture कसरी implement गर्ने भन्ने उदाहरण हेरौं।

## What's next

- [Security](../mcp-security/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत भए तापनि, कृपया बुझ्नुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै प्रामाणिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट हुने कुनै पनि गलत बुझाइ वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।