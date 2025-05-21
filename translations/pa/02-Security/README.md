<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:04:06+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pa"
}
-->
# ਸੁਰੱਖਿਆ ਦੀਆਂ ਸਭ ਤੋਂ ਵਧੀਆ ਪ੍ਰਥਾਵਾਂ

Model Context Protocol (MCP) ਨੂੰ ਅਪਣਾਉਣਾ AI-ਚਲਿਤ ਐਪਲੀਕੇਸ਼ਨਾਂ ਵਿੱਚ ਸ਼ਕਤੀਸ਼ਾਲੀ ਨਵੀਆਂ ਸਮਰੱਥਾਵਾਂ ਲਿਆਉਂਦਾ ਹੈ, ਪਰ ਇਸ ਨਾਲ ਪਰੰਪਰਾਗਤ ਸਾਫਟਵੇਅਰ ਖ਼ਤਰਨਾਂ ਤੋਂ ਵੱਧ ਵਿਲੱਖਣ ਸੁਰੱਖਿਆ ਚੁਣੌਤੀਆਂ ਵੀ ਆਉਂਦੀਆਂ ਹਨ। ਸੁਰੱਖਿਅਤ ਕੋਡਿੰਗ, ਘੱਟੋ-ਘੱਟ ਅਧਿਕਾਰ, ਅਤੇ ਸਪਲਾਈ ਚੇਨ ਸੁਰੱਖਿਆ ਵਰਗੀਆਂ ਮੌਜੂਦਾ ਚਿੰਤਾਵਾਂ ਦੇ ਨਾਲ ਨਾਲ, MCP ਅਤੇ AI ਵਰਕਲੋਡ ਨੂੰ ਨਵੀਆਂ ਧਮਕੀਆਂ ਦਾ ਸਾਹਮਣਾ ਕਰਨਾ ਪੈਂਦਾ ਹੈ ਜਿਵੇਂ ਕਿ prompt injection, tool poisoning, ਅਤੇ dynamic tool modification। ਜੇਕਰ ਇਹਨਾਂ ਖ਼ਤਰਨਾਂ ਨੂੰ ਠੀਕ ਤਰ੍ਹਾਂ ਮੈਨੇਜ ਨਾ ਕੀਤਾ ਜਾਵੇ ਤਾਂ ਇਹ ਡਾਟਾ ਚੋਰੀ, ਪਰਾਈਵੇਸੀ ਦੀ ਉਲੰਘਣਾ, ਅਤੇ ਅਣਚਾਹੇ ਸਿਸਟਮ ਵਿਹਾਰ ਨੂੰ ਜਨਮ ਦੇ ਸਕਦੇ ਹਨ।

ਇਸ ਪਾਠ ਵਿੱਚ MCP ਨਾਲ ਜੁੜੀਆਂ ਸਭ ਤੋਂ ਸੰਬੰਧਿਤ ਸੁਰੱਖਿਆ ਖ਼ਤਰਨਾਂ — ਜਿਵੇਂ ਕਿ authentication, authorization, ਜ਼ਿਆਦਾ ਅਧਿਕਾਰ, indirect prompt injection, ਅਤੇ supply chain vulnerabilities — ਦਾ ਵਿਸਤਾਰ ਨਾਲ ਅਧਿਐਨ ਕੀਤਾ ਗਿਆ ਹੈ ਅਤੇ ਉਨ੍ਹਾਂ ਨੂੰ ਘਟਾਉਣ ਲਈ ਕਾਰਗਰ ਕੰਟਰੋਲ ਅਤੇ ਸਰਵੋਤਮ ਅਭਿਆਸ ਦਿੱਤੇ ਗਏ ਹਨ। ਤੁਸੀਂ Microsoft ਦੇ ਹੱਲਾਂ ਜਿਵੇਂ ਕਿ Prompt Shields, Azure Content Safety, ਅਤੇ GitHub Advanced Security ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਆਪਣੇ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਨੂੰ ਮਜ਼ਬੂਤ ਬਣਾਉਣ ਬਾਰੇ ਵੀ ਸਿੱਖੋਗੇ। ਇਹਨਾਂ ਕੰਟਰੋਲਾਂ ਨੂੰ ਸਮਝ ਕੇ ਅਤੇ ਲਾਗੂ ਕਰਕੇ, ਤੁਸੀਂ ਸੁਰੱਖਿਆ ਭੰਗ ਹੋਣ ਦੀ ਸੰਭਾਵਨਾ ਨੂੰ ਕਾਫ਼ੀ ਘਟਾ ਸਕਦੇ ਹੋ ਅਤੇ ਆਪਣੇ AI ਸਿਸਟਮਾਂ ਨੂੰ ਭਰੋਸੇਯੋਗ ਅਤੇ ਮਜ਼ਬੂਤ ਬਣਾ ਸਕਦੇ ਹੋ।

# ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- Model Context Protocol (MCP) ਨਾਲ ਜੁੜੀਆਂ ਵਿਲੱਖਣ ਸੁਰੱਖਿਆ ਖ਼ਤਰਨਾਂ ਨੂੰ ਪਛਾਣਣਾ ਅਤੇ ਸਮਝਾਉਣਾ, ਜਿਵੇਂ ਕਿ prompt injection, tool poisoning, ਜ਼ਿਆਦਾ ਅਧਿਕਾਰ, ਅਤੇ supply chain vulnerabilities।
- MCP ਸੁਰੱਖਿਆ ਖ਼ਤਰਨਾਂ ਲਈ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਰੋਕਥਾਮ ਕੰਟਰੋਲ ਲਾਗੂ ਕਰਨਾ, ਜਿਵੇਂ ਕਿ ਮਜ਼ਬੂਤ authentication, ਘੱਟੋ-ਘੱਟ ਅਧਿਕਾਰ, ਸੁਰੱਖਿਅਤ ਟੋਕਨ ਪ੍ਰਬੰਧਨ, ਅਤੇ supply chain verification।
- Microsoft ਦੇ ਹੱਲਾਂ ਜਿਵੇਂ ਕਿ Prompt Shields, Azure Content Safety, ਅਤੇ GitHub Advanced Security ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਅਤੇ AI ਵਰਕਲੋਡ ਦੀ ਸੁਰੱਖਿਆ ਕਰਨਾ।
- ਟੂਲ ਮੈਟਾਡੇਟਾ ਦੀ ਵੈਧਤਾ, ਡਾਇਨਾਮਿਕ ਬਦਲਾਵਾਂ ਦੀ ਨਿਗਰਾਨੀ, ਅਤੇ indirect prompt injection ਹਮਲਿਆਂ ਤੋਂ ਬਚਾਅ ਦੀ ਮਹੱਤਤਾ ਨੂੰ ਸਮਝਣਾ।
- MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਵਿੱਚ ਸੁਰੱਖਿਆ ਦੇ ਮੌਜੂਦਾ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ ਨੂੰ ਸ਼ਾਮਿਲ ਕਰਨਾ — ਜਿਵੇਂ ਕਿ ਸੁਰੱਖਿਅਤ ਕੋਡਿੰਗ, ਸਰਵਰ ਹਾਰਡਨਿੰਗ, ਅਤੇ ਜ਼ੀਰੋ ਟਰੱਸਟ ਆਰਕੀਟੈਕਚਰ — ਤਾਂ ਜੋ ਸੁਰੱਖਿਆ ਭੰਗ ਹੋਣ ਦੀ ਸੰਭਾਵਨਾ ਅਤੇ ਪ੍ਰਭਾਵ ਘਟੇ।

# MCP ਸੁਰੱਖਿਆ ਕੰਟਰੋਲ

ਕੋਈ ਵੀ ਸਿਸਟਮ ਜਿਸਦੇ ਕੋਲ ਮਹੱਤਵਪੂਰਨ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਹੁੰਦੀ ਹੈ, ਉਸਦੇ ਲਈ ਸੁਰੱਖਿਆ ਚੁਣੌਤੀਆਂ ਹੁੰਦੀਆਂ ਹਨ। ਇਹਨਾਂ ਚੁਣੌਤੀਆਂ ਨੂੰ ਆਮ ਤੌਰ 'ਤੇ ਮੂਲ ਸੁਰੱਖਿਆ ਕੰਟਰੋਲ ਅਤੇ ਸੰਕਲਪਾਂ ਦੇ ਸਹੀ ਲਾਗੂ ਕਰਨ ਨਾਲ ਹੱਲ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। MCP ਹਾਲੇ ਨਵਾਂ ਪਰਿਭਾਸ਼ਿਤ ਕੀਤਾ ਗਿਆ ਹੈ, ਇਸ ਲਈ ਇਸਦੀ ਵਿਸ਼ੇਸ਼ਤਾਵਾਂ ਤੇਜ਼ੀ ਨਾਲ ਬਦਲ ਰਹੀਆਂ ਹਨ ਅਤੇ ਜਿਵੇਂ ਜਿਵੇਂ ਪ੍ਰੋਟੋਕਾਲ ਵਿਕਸਿਤ ਹੋ ਰਿਹਾ ਹੈ, ਸੁਰੱਖਿਆ ਕੰਟਰੋਲ ਵੀ ਪੱਕੇ ਹੋਣਗੇ, ਜਿਸ ਨਾਲ ਉਦਯੋਗ ਅਤੇ ਮੌਜੂਦਾ ਸੁਰੱਖਿਆ ਆਰਕੀਟੈਕਚਰਾਂ ਅਤੇ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ ਨਾਲ ਵਧੀਆ ਇੰਟਿਗ੍ਰੇਸ਼ਨ ਹੋਵੇਗਾ।

[Microsoft Digital Defense Report](https://aka.ms/mddr) ਵਿੱਚ ਪ੍ਰਕਾਸ਼ਿਤ ਰਿਸਰਚ ਮੁਤਾਬਕ, 98% ਰਿਪੋਰਟ ਕੀਤੀਆਂ ਸੁਰੱਖਿਆ ਭੰਗਾਂ ਨੂੰ ਮਜ਼ਬੂਤ ਸੁਰੱਖਿਆ ਸਫਾਈ ਨਾਲ ਰੋਕਿਆ ਜਾ ਸਕਦਾ ਹੈ ਅਤੇ ਕਿਸੇ ਵੀ ਕਿਸਮ ਦੀ ਭੰਗ ਤੋਂ ਬਚਾਅ ਲਈ ਸਭ ਤੋਂ ਵਧੀਆ ਸੁਰੱਖਿਆ ਇਹ ਹੈ ਕਿ ਤੁਸੀਂ ਆਪਣੀ ਬੇਸਲਾਈਨ ਸੁਰੱਖਿਆ ਸਫਾਈ, ਸੁਰੱਖਿਅਤ ਕੋਡਿੰਗ ਸਰਵੋਤਮ ਅਭਿਆਸ, ਅਤੇ ਸਪਲਾਈ ਚੇਨ ਸੁਰੱਖਿਆ ਨੂੰ ਠੀਕ ਰੱਖੋ — ਇਹ ਪਰਖੇ-ਤਸਦੀਕ ਕੀਤੇ ਅਭਿਆਸ ਅਜੇ ਵੀ ਸੁਰੱਖਿਆ ਖ਼ਤਰੇ ਨੂੰ ਘਟਾਉਣ ਵਿੱਚ ਸਭ ਤੋਂ ਵੱਡਾ ਪ੍ਰਭਾਵ ਰੱਖਦੇ ਹਨ।

ਆਓ ਕੁਝ ਤਰੀਕੇ ਵੇਖੀਏ ਜਿਨ੍ਹਾਂ ਨਾਲ ਤੁਸੀਂ MCP ਅਪਣਾਉਂਦੇ ਸਮੇਂ ਸੁਰੱਖਿਆ ਖ਼ਤਰਨਾਂ ਨੂੰ ਸੰਭਾਲ ਸਕਦੇ ਹੋ।

# MCP ਸਰਵਰ authentication (ਜੇ ਤੁਹਾਡਾ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ 26 ਅਪ੍ਰੈਲ 2025 ਤੋਂ ਪਹਿਲਾਂ ਸੀ)

> **Note:** ਹੇਠਾਂ ਦਿੱਤੀ ਜਾਣਕਾਰੀ 26 ਅਪ੍ਰੈਲ 2025 ਤੱਕ ਸਹੀ ਹੈ। MCP ਪ੍ਰੋਟੋਕਾਲ ਲਗਾਤਾਰ ਵਿਕਸਤ ਹੋ ਰਿਹਾ ਹੈ, ਅਤੇ ਭਵਿੱਖ ਵਿੱਚ ਨਵੇਂ authentication ਪੈਟਰਨ ਅਤੇ ਕੰਟਰੋਲ ਆ ਸਕਦੇ ਹਨ। ਤਾਜ਼ਾ ਅੱਪਡੇਟਸ ਅਤੇ ਮਾਰਗਦਰਸ਼ਨ ਲਈ ਹਮੇਸ਼ਾ [MCP Specification](https://spec.modelcontextprotocol.io/) ਅਤੇ ਅਧਿਕਾਰਿਕ [MCP GitHub repository](https://github.com/modelcontextprotocol) ਨੂੰ ਵੇਖੋ।

### ਸਮੱਸਿਆ ਦਾ ਬਿਆਨ  
ਮੂਲ MCP ਵਿਸ਼ੇਸ਼ਤਾ ਇਹ ਮੰਨਦੀ ਸੀ ਕਿ ਵਿਕਾਸਕਾਰ ਆਪਣਾ authentication ਸਰਵਰ ਲਿਖਣਗੇ। ਇਸ ਲਈ OAuth ਅਤੇ ਸਬੰਧਤ ਸੁਰੱਖਿਆ ਸੀਮਾਵਾਂ ਦੀ ਜਾਣਕਾਰੀ ਲੋੜੀਂਦੀ ਸੀ। MCP ਸਰਵਰ OAuth 2.0 Authorization Servers ਵਾਂਗ ਕੰਮ ਕਰਦੇ ਸਨ, ਜਿਹੜੇ ਯੂਜ਼ਰ authentication ਨੂੰ ਸਿੱਧਾ ਸੰਭਾਲਦੇ ਸਨ ਬਜਾਏ ਕਿਸੇ ਬਾਹਰੀ ਸੇਵਾ ਜਿਵੇਂ Microsoft Entra ID ਨੂੰ ਸੌਂਪਣ ਦੇ। 26 ਅਪ੍ਰੈਲ 2025 ਤੋਂ, MCP ਵਿਸ਼ੇਸ਼ਤਾ ਵਿੱਚ ਇੱਕ ਅੱਪਡੇਟ ਆਈ ਹੈ ਜੋ MCP ਸਰਵਰਾਂ ਨੂੰ ਯੂਜ਼ਰ authentication ਬਾਹਰੀ ਸੇਵਾ ਨੂੰ ਸੌਂਪਣ ਦੀ ਆਗਿਆ ਦਿੰਦੀ ਹੈ।

### ਖ਼ਤਰੇ  
- MCP ਸਰਵਰ ਵਿੱਚ authorization ਲਾਜਿਕ ਦੀ ਗਲਤ ਸੰਰਚਨਾ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਦੇ ਪ੍ਰਗਟਾਵੇ ਅਤੇ ਗਲਤ ਤਰੀਕੇ ਨਾਲ ਲਾਗੂ ਕੀਤੇ ਗਏ ਪਹੁੰਚ ਨਿਯੰਤਰਣਾਂ ਦਾ ਕਾਰਨ ਬਣ ਸਕਦੀ ਹੈ।  
- OAuth ਟੋਕਨ ਦੀ ਚੋਰੀ, ਜੇਕਰ ਟੋਕਨ ਚੋਰੀ ਹੋ ਜਾਂਦਾ ਹੈ ਤਾਂ ਇਸਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕੋਈ MCP ਸਰਵਰ ਦਾ ਭੇਸ ਧਾਰ ਕੇ ਸੇਵਾ ਦੇ ਸਰੋਤਾਂ ਅਤੇ ਡਾਟਾ ਤੱਕ ਪਹੁੰਚ ਪ੍ਰਾਪਤ ਕਰ ਸਕਦਾ ਹੈ।

### ਰੋਕਥਾਮ ਕੰਟਰੋਲ  
- **Authorization Logic ਦੀ ਸਮੀਖਿਆ ਅਤੇ ਮਜ਼ਬੂਤੀ:** ਆਪਣੇ MCP ਸਰਵਰ ਦੀ authorization ਲਾਗੂਆਈ ਦੀ ਧਿਆਨ ਨਾਲ ਜਾਂਚ ਕਰੋ ਤਾਂ ਜੋ ਸਿਰਫ਼ ਮੰਨਿਆ ਹੋਇਆ ਯੂਜ਼ਰ ਅਤੇ ਕਲਾਇੰਟ ਸੰਵੇਦਨਸ਼ੀਲ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਸਕਣ। ਵਿਹਾਰਕ ਮਦਦ ਲਈ ਵੇਖੋ [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) ਅਤੇ [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)।  
- **ਸੁਰੱਖਿਅਤ ਟੋਕਨ ਅਭਿਆਸ ਲਾਗੂ ਕਰੋ:** [Microsoft ਦੀਆਂ ਟੋਕਨ ਵੈਧਤਾ ਅਤੇ ਲਾਈਫਟਾਈਮ ਲਈ ਸਰਵੋਤਮ ਅਭਿਆਸਾਂ](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ਦੀ ਪਾਲਣਾ ਕਰੋ ਤਾਂ ਜੋ ਟੋਕਨ ਦੀ ਗਲਤ ਵਰਤੋਂ ਜਾਂ ਚੋਰੀ ਤੋਂ ਬਚਾ ਜਾ ਸਕੇ।  
- **ਟੋਕਨ ਸਟੋਰੇਜ ਦੀ ਸੁਰੱਖਿਆ ਕਰੋ:** ਟੋਕਨਾਂ ਨੂੰ ਸੁਰੱਖਿਅਤ ਢੰਗ ਨਾਲ ਸਟੋਰ ਕਰੋ ਅਤੇ ਇਨਕ੍ਰਿਪਸ਼ਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਉਹਨਾਂ ਨੂੰ ਰੈਸਟ ਅਤੇ ਟ੍ਰਾਂਜ਼ਿਟ ਦੌਰਾਨ ਸੁਰੱਖਿਅਤ ਰੱਖੋ। ਲਾਗੂ ਕਰਨ ਲਈ ਸਲਾਹ ਲਈ ਵੇਖੋ [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)।

# MCP ਸਰਵਰਾਂ ਲਈ ਜ਼ਿਆਦਾ ਅਧਿਕਾਰ

### ਸਮੱਸਿਆ ਦਾ ਬਿਆਨ  
MCP ਸਰਵਰਾਂ ਨੂੰ ਉਹਨਾਂ ਦੀ ਲੋੜ ਤੋਂ ਵੱਧ ਸੇਵਾ ਜਾਂ ਸਰੋਤਾਂ ਲਈ ਅਧਿਕਾਰ ਦਿੱਤੇ ਗਏ ਹੋ ਸਕਦੇ ਹਨ। ਉਦਾਹਰਨ ਵਜੋਂ, ਇੱਕ MCP ਸਰਵਰ ਜੋ ਇੱਕ AI ਸੇਲਜ਼ ਐਪਲੀਕੇਸ਼ਨ ਦਾ ਹਿੱਸਾ ਹੈ ਅਤੇ ਇੱਕ ਉਦਯੋਗਿਕ ਡਾਟਾ ਸਟੋਰ ਨਾਲ ਜੁੜਿਆ ਹੈ, ਉਸਨੂੰ ਸਿਰਫ ਸੇਲਜ਼ ਡਾਟਾ ਤੱਕ ਹੀ ਪਹੁੰਚ ਮਿਲਣੀ ਚਾਹੀਦੀ ਹੈ, ਸਾਰੇ ਫਾਈਲਾਂ ਤੱਕ ਨਹੀਂ। ਘੱਟੋ-ਘੱਟ ਅਧਿਕਾਰ ਦਾ ਸਿਧਾਂਤ (ਜੋ ਸਭ ਤੋਂ ਪੁਰਾਣਾ ਸੁਰੱਖਿਆ ਸਿਧਾਂਤ ਹੈ) ਕਹਿੰਦਾ ਹੈ ਕਿ ਕਿਸੇ ਵੀ ਸਰੋਤ ਨੂੰ ਉਸਦੇ ਕੰਮ ਲਈ ਲੋੜੀਂਦੇ ਅਧਿਕਾਰ ਤੋਂ ਵੱਧ ਅਧਿਕਾਰ ਨਹੀਂ ਮਿਲਣੇ ਚਾਹੀਦੇ। AI ਇਸ ਖੇਤਰ ਵਿੱਚ ਵੱਧ ਚੁਣੌਤੀ ਪੈਦਾ ਕਰਦਾ ਹੈ ਕਿਉਂਕਿ ਇਸਨੂੰ ਲਚਕੀਲਾ ਬਣਾਉਣ ਲਈ ਸਹੀ ਅਧਿਕਾਰ ਨਿਰਧਾਰਿਤ ਕਰਨਾ ਮੁਸ਼ਕਲ ਹੁੰਦਾ ਹੈ।

### ਖ਼ਤਰੇ  
- ਜ਼ਿਆਦਾ ਅਧਿਕਾਰ ਦੇਣ ਨਾਲ MCP ਸਰਵਰ ਉਹ ਡਾਟਾ ਚੋਰੀ ਜਾਂ ਸੋਧ ਕਰ ਸਕਦਾ ਹੈ ਜਿਸ ਦੀ ਉਸਨੂੰ ਪਹੁੰਚ ਨਹੀਂ ਹੋਣੀ ਚਾਹੀਦੀ। ਇਹ ਪਰਾਈਵੇਸੀ ਦੀ ਸਮੱਸਿਆ ਵੀ ਬਣ ਸਕਦੀ ਹੈ ਜੇ ਡਾਟਾ ਵਿਅਕਤੀਗਤ ਪਛਾਣਯੋਗ ਜਾਣਕਾਰੀ (PII) ਹੋਵੇ।

### ਰੋਕਥਾਮ ਕੰਟਰੋਲ  
- **ਘੱਟੋ-ਘੱਟ ਅਧਿਕਾਰ ਦਾ ਸਿਧਾਂਤ ਲਾਗੂ ਕਰੋ:** MCP ਸਰਵਰ ਨੂੰ ਸਿਰਫ਼ ਜਰੂਰੀ ਕੰਮ ਕਰਨ ਲਈ ਲੋੜੀਂਦੇ ਘੱਟੋ-ਘੱਟ ਅਧਿਕਾਰ ਦਿਓ। ਸਮੇਂ-ਸਮੇਂ 'ਤੇ ਇਹ ਅਧਿਕਾਰ ਸਮੀਖਿਆ ਕਰੋ ਅਤੇ ਅਪਡੇਟ ਕਰੋ ਤਾਂ ਜੋ ਇਹ ਲੋੜ ਤੋਂ ਵੱਧ ਨਾ ਹੋਣ। ਵਿਸਤਾਰ ਲਈ ਵੇਖੋ [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)।  
- **Role-Based Access Control (RBAC) ਦੀ ਵਰਤੋਂ ਕਰੋ:** MCP ਸਰਵਰ ਨੂੰ ਉਹ ਰੋਲ ਸੌਂਪੋ ਜੋ ਨਿਰਧਾਰਿਤ ਸਰੋਤਾਂ ਅਤੇ ਕਾਰਵਾਈਆਂ ਤੱਕ ਸੀਮਿਤ ਹੋਣ, ਅਤੇ ਵਿਆਪਕ ਜਾਂ ਬੇਕਾਰ ਅਧਿਕਾਰ ਤੋਂ ਬਚੋ।  
- **ਅਧਿਕਾਰਾਂ ਦੀ ਨਿਗਰਾਨੀ ਅਤੇ ਆਡਿਟ ਕਰੋ:** ਅਧਿਕਾਰਾਂ ਦੀ ਵਰਤੋਂ ਨੂੰ ਲਗਾਤਾਰ ਨਿਗਰਾਨੀ ਕਰੋ ਅਤੇ ਐਕਸੈੱਸ ਲੌਗਾਂ ਦਾ ਆਡਿਟ ਕਰੋ ਤਾਂ ਜੋ ਜ਼ਿਆਦਾ ਜਾਂ ਬੇਕਾਰ ਅਧਿਕਾਰਾਂ ਦਾ ਤੁਰੰਤ ਪਤਾ ਲੱਗੇ ਅਤੇ ਉਨ੍ਹਾਂ ਨੂੰ ਹਟਾਇਆ ਜਾ ਸਕੇ।

# ਪਰੋਖ prompt injection ਹਮਲੇ

### ਸਮੱਸਿਆ ਦਾ ਬਿਆਨ

ਦੁਸ਼ਮਣ MCP ਸਰਵਰ ਗਾਹਕਾਂ ਦਾ ਡਾਟਾ ਬਾਹਰ ਕੱਢਣ ਜਾਂ ਅਣਚਾਹੇ ਕੰਮ ਕਰਵਾਉਣ ਦੇ ਖ਼ਤਰੇ ਪੈਦਾ ਕਰ ਸਕਦੇ ਹਨ। ਇਹ ਖ਼ਤਰੇ ਖ਼ਾਸ ਕਰਕੇ AI ਅਤੇ MCP-ਅਧਾਰਿਤ ਵਰਕਲੋਡਾਂ ਵਿੱਚ ਮਾਇਨੇ ਰੱਖਦੇ ਹਨ, ਜਿੱਥੇ:

- **Prompt Injection Attacks**: ਹਮਲਾਵਰ prompts ਜਾਂ ਬਾਹਰੀ ਸਮੱਗਰੀ ਵਿੱਚ ਦੁਸ਼ਮਣੀ ਭਰੇ ਹੁਕਮ ਸ਼ਾਮਿਲ ਕਰਦੇ ਹਨ, ਜਿਸ ਨਾਲ AI ਸਿਸਟਮ ਅਣਚਾਹੇ ਕੰਮ ਕਰਦਾ ਹੈ ਜਾਂ ਸੰਵੇਦਨਸ਼ੀਲ ਡਾਟਾ ਲੀਕ ਕਰਦਾ ਹੈ। ਵਧੇਰੇ ਜਾਣਕਾਰੀ ਲਈ ਵੇਖੋ: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Tool Poisoning**: ਹਮਲਾਵਰ ਟੂਲ ਮੈਟਾਡੇਟਾ (ਜਿਵੇਂ ਵਰਣਨ ਜਾਂ ਪੈਰਾਮੀਟਰ) ਨੂੰ ਬਦਲ ਕੇ AI ਦੇ ਵਿਹਾਰ ਨੂੰ ਪ੍ਰਭਾਵਿਤ ਕਰਦੇ ਹਨ, ਜਿਸ ਨਾਲ ਸੁਰੱਖਿਆ ਕੰਟਰੋਲਾਂ ਨੂੰ ਬਾਈਪਾਸ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ ਜਾਂ ਡਾਟਾ ਚੋਰੀ ਹੋ ਸਕਦੀ ਹੈ। ਵੇਰਵਾ: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Cross-Domain Prompt Injection**: ਦੁਸ਼ਮਣੀ ਭਰੇ ਹੁਕਮ ਦਸਤਾਵੇਜ਼ਾਂ, ਵੈੱਬ ਪੰਨਿਆਂ ਜਾਂ ਈਮੇਲਾਂ ਵਿੱਚ ਸ਼ਾਮਿਲ ਹੁੰਦੇ ਹਨ, ਜਿਹੜੇ AI ਦੁਆਰਾ ਪ੍ਰਕਿਰਿਆ ਕੀਤੇ ਜਾਂਦੇ ਹਨ, ਜਿਸ ਨਾਲ ਡਾਟਾ ਲੀਕ ਜਾਂ ਸੋਧ ਹੋ ਸਕਦੀ ਹੈ।  
- **Dynamic Tool Modification (Rug Pulls)**: ਟੂਲ ਦੀ ਪਰਿਭਾਸ਼ਾ ਯੂਜ਼ਰ ਦੀ ਮਨਜ਼ੂਰੀ ਤੋਂ ਬਾਅਦ ਬਦਲੀ ਜਾ ਸਕਦੀ ਹੈ, ਜਿਸ ਨਾਲ ਨਵੀਆਂ ਦੁਸ਼ਮਣੀ ਭਰੀਆਂ ਕਾਰਵਾਈਆਂ ਬਿਨਾਂ ਯੂਜ਼ਰ ਦੇ ਪਤਾ ਲੱਗਣ ਦੇ ਆ ਸਕਦੀਆਂ ਹਨ।

ਇਹ ਖ਼ਤਰੇ MCP ਸਰਵਰਾਂ ਅਤੇ ਟੂਲਾਂ ਨੂੰ ਤੁਹਾਡੇ ਵਾਤਾਵਰਣ ਵਿੱਚ ਜੋੜਦੇ ਸਮੇਂ ਮਜ਼ਬੂਤ ਵੈਧਤਾ, ਨਿਗਰਾਨੀ, ਅਤੇ ਸੁਰੱਖਿਆ ਕੰਟਰੋਲਾਂ ਦੀ ਲੋੜ ਨੂੰ ਦਰਸਾਉਂਦੇ ਹਨ। ਵਧੇਰੇ ਜਾਣਕਾਰੀ ਲਈ ਉਪਰ ਦਿੱਤੇ ਲਿੰਕ ਵੇਖੋ।

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pa.png)

**ਪਰੋਖ Prompt Injection** (ਜਿਸਨੂੰ cross-domain prompt injection ਜਾਂ XPIA ਵੀ ਕਹਿੰਦੇ ਹਨ) ਜਨਰੇਟਿਵ AI ਸਿਸਟਮਾਂ ਵਿੱਚ ਇੱਕ ਗੰਭੀਰ ਖ਼ਤਰਾ ਹੈ, ਜਿਸ ਵਿੱਚ Model Context Protocol (MCP) ਵੀ ਸ਼ਾਮਿਲ ਹੈ। ਇਸ ਹਮਲੇ ਵਿੱਚ, ਦੁਸ਼ਮਣੀ ਭਰੇ ਹੁਕਮ ਬਾਹਰੀ ਸਮੱਗਰੀ — ਜਿਵੇਂ ਦਸਤਾਵੇਜ਼, ਵੈੱਬ ਪੰਨੇ, ਜਾਂ ਈਮੇਲਾਂ — ਵਿੱਚ ਛੁਪਾਏ ਜਾਂਦੇ ਹਨ। ਜਦੋਂ AI ਸਿਸਟਮ ਇਸ ਸਮੱਗਰੀ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਦਾ ਹੈ, ਤਾਂ ਇਹ ਛੁਪੇ ਹੁਕਮਾਂ ਨੂੰ ਵੈਧ ਯੂਜ਼ਰ ਹੁਕਮਾਂ ਵਾਂਗ ਸਮਝ ਸਕਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਅਣਚਾਹੇ ਕੰਮ ਜਿਵੇਂ ਡਾਟਾ ਲੀਕ, ਹਾਨਿਕਾਰਕ ਸਮੱਗਰੀ ਬਣਾਉਣਾ, ਜਾਂ ਯੂਜ਼ਰ ਇੰਟਰੈਕਸ਼ਨਾਂ ਵਿੱਚ ਤਬਦੀਲੀ ਹੋ ਸਕਦੀ ਹੈ। ਵਿਸਤਾਰ ਲਈ ਅਤੇ ਅਸਲੀ ਉਦਾਹਰਣਾਂ ਲਈ ਵੇਖੋ [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)।

ਇਸ ਹਮਲੇ ਦਾ ਖ਼ਤਰਨਾਕ ਰੂਪ **Tool Poisoning** ਹੈ। ਇਸ ਵਿੱਚ, ਹਮਲਾਵਰ MCP ਟੂਲਾਂ ਦੇ ਮੈਟਾਡੇਟਾ (ਜਿਵੇਂ ਟੂਲ ਦੇ ਵਰਣਨ ਜਾਂ ਪੈਰਾਮੀਟਰ) ਵਿੱਚ ਦੁਸ਼ਮਣੀ ਭਰੇ ਹੁਕਮ ਛੁਪਾ ਦਿੰਦੇ ਹਨ। ਵੱਡੇ ਭਾਸ਼ਾ ਮਾਡਲ (LLMs) ਇਸ ਮੈਟਾਡੇਟਾ 'ਤੇ ਆਧਾਰਿਤ ਫੈਸਲਾ ਕਰਦੇ ਹਨ ਕਿ ਕਿਹੜੇ ਟੂਲ ਕਾਲ ਕਰਨੇ ਹਨ, ਇਸ ਲਈ ਬਦਲਿਆ ਹੋਇਆ ਵਰਣਨ ਮਾਡਲ ਨੂੰ ਗਲਤ ਟੂਲ ਕਾਲ ਕਰਨ ਜਾਂ ਸੁਰੱਖਿਆ ਕੰਟਰੋਲਾਂ ਨੂੰ ਬਾਈਪਾਸ ਕਰਨ ਲਈ ਧੋਖਾ ਦੇ ਸਕਦਾ ਹੈ। ਇਹ ਤਬਦੀਲੀਆਂ ਆਮ ਤੌਰ 'ਤੇ ਅੰਤਮ ਯੂਜ਼ਰਾਂ ਨੂੰ ਨਹੀਂ ਦਿਖਦੀਆਂ ਪਰ AI ਸਿਸਟਮ ਵੱਲੋਂ ਸਮਝੀਆਂ ਅਤੇ ਕਾਰਵਾਈਆਂ ਕੀਤੀਆਂ ਜਾ ਸਕਦੀਆਂ ਹਨ। ਇਹ ਖ਼ਤਰਾ ਹੋਸਟ
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### ਅਗਲਾ

ਅਗਲਾ: [ਅਧਿਆਇ 3: ਸ਼ੁਰੂਆਤ](/03-GettingStarted/README.md)

**ਡਿਸਕਲੇਮਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਨਾਲ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।