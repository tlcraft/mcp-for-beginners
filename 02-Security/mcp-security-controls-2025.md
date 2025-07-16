# Latest MCP Security Controls - July 2025 Update

As the Model Context Protocol (MCP) continues to evolve, security remains a critical consideration. This document outlines the latest security controls and best practices for implementing MCP securely as of July 2025.

## Authentication and Authorization

### OAuth 2.0 Delegation Support

Recent updates to the MCP specification now allow MCP servers to delegate user authentication to external services such as Microsoft Entra ID. This significantly improves the security posture by:

1. **Eliminating Custom Auth Implementation**: Reduces the risk of security flaws in custom authentication code
2. **Leveraging Established Identity Providers**: Benefits from enterprise-grade security features
3. **Centralizing Identity Management**: Simplifies user lifecycle management and access control


## Token Passthrough Prevention

The MCP Authorization Specification explicitly forbids token passthrough to prevent security control circumvention and accountability issues.

### Key Requirements

1. **MCP servers MUST NOT accept tokens not issued for them**: Validate that all tokens have the correct audience claim
2. **Implement proper token validation**: Check issuer, audience, expiration, and signature
3. **Use separate token issuance**: Issue new tokens for downstream services rather than passing through existing tokens

## Secure Session Management

To prevent session hijacking and fixation attacks, implement the following controls:

1. **Use secure, non-deterministic session IDs**: Generated with cryptographically secure random number generators
2. **Bind sessions to user identity**: Combine session IDs with user-specific information
3. **Implement proper session rotation**: After authentication changes or privilege escalation
4. **Set appropriate session timeouts**: Balance security with user experience


## Tool Execution Sandboxing

To prevent lateral movement and contain potential compromises:

1. **Isolate tool execution environments**: Use containers or separate processes
2. **Apply resource limits**: Prevent resource exhaustion attacks
3. **Implement least privilege access**: Grant only necessary permissions
4. **Monitor execution patterns**: Detect anomalous behavior

## Tool Definition Protection

To prevent tool poisoning:

1. **Validate tool definitions before use**: Check for malicious instructions or inappropriate patterns
2. **Use integrity verification**: Hash or sign tool definitions to detect unauthorized changes
3. **Implement change monitoring**: Alert on unexpected modifications to tool metadata
4. **Version control tool definitions**: Track changes and enable rollback if needed

These controls work together to create a robust security posture for MCP implementations, addressing the unique challenges of AI-driven systems while maintaining strong traditional security practices.
