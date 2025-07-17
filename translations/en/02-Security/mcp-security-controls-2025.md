<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:38:21+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "en"
}
-->
# Latest MCP Security Controls - July 2025 Update

As the Model Context Protocol (MCP) continues to evolve, security remains a critical focus. This document outlines the latest security controls and best practices for securely implementing MCP as of July 2025.

## Authentication and Authorization

### OAuth 2.0 Delegation Support

Recent updates to the MCP specification now allow MCP servers to delegate user authentication to external services like Microsoft Entra ID. This greatly enhances security by:

1. **Eliminating Custom Auth Implementation**: Reduces the risk of vulnerabilities in custom authentication code  
2. **Leveraging Established Identity Providers**: Takes advantage of enterprise-grade security features  
3. **Centralizing Identity Management**: Simplifies user lifecycle management and access control  


## Token Passthrough Prevention

The MCP Authorization Specification explicitly prohibits token passthrough to avoid bypassing security controls and accountability issues.

### Key Requirements

1. **MCP servers MUST NOT accept tokens not issued for them**: Ensure all tokens have the correct audience claim  
2. **Implement proper token validation**: Verify issuer, audience, expiration, and signature  
3. **Use separate token issuance**: Generate new tokens for downstream services instead of passing existing tokens through  

## Secure Session Management

To guard against session hijacking and fixation attacks, apply the following controls:

1. **Use secure, non-deterministic session IDs**: Generate them with cryptographically secure random number generators  
2. **Bind sessions to user identity**: Link session IDs with user-specific information  
3. **Implement proper session rotation**: Rotate sessions after authentication changes or privilege escalation  
4. **Set appropriate session timeouts**: Find a balance between security and user experience  


## Tool Execution Sandboxing

To prevent lateral movement and contain potential breaches:

1. **Isolate tool execution environments**: Use containers or separate processes  
2. **Apply resource limits**: Avoid resource exhaustion attacks  
3. **Implement least privilege access**: Grant only the permissions necessary  
4. **Monitor execution patterns**: Detect unusual behavior  

## Tool Definition Protection

To prevent tool poisoning:

1. **Validate tool definitions before use**: Check for malicious instructions or suspicious patterns  
2. **Use integrity verification**: Hash or sign tool definitions to detect unauthorized changes  
3. **Implement change monitoring**: Alert on unexpected modifications to tool metadata  
4. **Version control tool definitions**: Track changes and enable rollback if needed  

Together, these controls establish a strong security foundation for MCP implementations, addressing the unique challenges of AI-driven systems while maintaining solid traditional security practices.

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.