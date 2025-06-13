<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-12T23:29:56+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "ne"
}
-->
## Distributed Architecture

Distributed architecture मा धेरै MCP nodes सँगै काम गर्छन् जसले requests हरु handle गर्छ, resources share गर्छ, र redundancy प्रदान गर्छ। यसले scalability र fault tolerance बढाउँछ किनभने nodes हरु distributed system मार्फत communicate र coordinate गर्न सक्छन्।

अब हामी Redis प्रयोग गरेर coordination को लागि distributed MCP server architecture कसरी implement गर्ने भन्ने उदाहरण हेरौं।

## What's next

- [5.8 Security](../mcp-security/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।