<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:45:05+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "en"
}
-->
# MCP Security Best Practices - July 2025 Update

## Comprehensive Security Best Practices for MCP Implementations

When working with MCP servers, follow these security best practices to protect your data, infrastructure, and users:

1. **Input Validation**: Always validate and sanitize inputs to prevent injection attacks and confused deputy problems.
   - Enforce strict validation for all tool parameters
   - Use schema validation to ensure requests match expected formats
   - Filter out potentially malicious content before processing

2. **Access Control**: Implement proper authentication and authorization for your MCP server with fine-grained permissions.
   - Use OAuth 2.0 with trusted identity providers like Microsoft Entra ID
   - Apply role-based access control (RBAC) for MCP tools
   - Avoid custom authentication when established solutions are available

3. **Secure Communication**: Use HTTPS/TLS for all communications with your MCP server and consider adding extra encryption for sensitive data.
   - Configure TLS 1.3 whenever possible
   - Use certificate pinning for critical connections
   - Regularly rotate certificates and verify their validity

4. **Rate Limiting**: Implement rate limiting to prevent abuse, DoS attacks, and manage resource usage.
   - Set appropriate request limits based on expected usage patterns
   - Use graduated responses to handle excessive requests
   - Consider user-specific rate limits depending on authentication status

5. **Logging and Monitoring**: Monitor your MCP server for suspicious activity and maintain comprehensive audit trails.
   - Log all authentication attempts and tool invocations
   - Set up real-time alerts for suspicious behavior
   - Ensure logs are securely stored and protected from tampering

6. **Secure Storage**: Protect sensitive data and credentials with proper encryption at rest.
   - Use key vaults or secure credential stores for all secrets
   - Apply field-level encryption for sensitive data
   - Rotate encryption keys and credentials regularly

7. **Token Management**: Prevent token passthrough vulnerabilities by validating and sanitizing all model inputs and outputs.
   - Validate tokens based on audience claims
   - Reject tokens not explicitly issued for your MCP server
   - Manage token lifetimes properly and rotate tokens as needed

8. **Session Management**: Implement secure session handling to prevent session hijacking and fixation attacks.
   - Use secure, unpredictable session IDs
   - Bind sessions to user-specific information
   - Enforce proper session expiration and rotation

9. **Tool Execution Sandboxing**: Run tool executions in isolated environments to prevent lateral movement if compromised.
   - Use container isolation for tool execution
   - Apply resource limits to prevent resource exhaustion attacks
   - Separate execution contexts for different security domains

10. **Regular Security Audits**: Conduct periodic security reviews of your MCP implementations and dependencies.
    - Schedule regular penetration tests
    - Use automated scanning tools to identify vulnerabilities
    - Keep dependencies up to date to address known security issues

11. **Content Safety Filtering**: Implement content safety filters for both inputs and outputs.
    - Use Azure Content Safety or similar services to detect harmful content
    - Apply prompt shield techniques to prevent prompt injection
    - Scan generated content for potential sensitive data leaks

12. **Supply Chain Security**: Verify the integrity and authenticity of all components in your AI supply chain.
    - Use signed packages and verify their signatures
    - Perform software bill of materials (SBOM) analysis
    - Monitor for malicious updates to dependencies

13. **Tool Definition Protection**: Prevent tool poisoning by securing tool definitions and metadata.
    - Validate tool definitions before use
    - Monitor for unexpected changes to tool metadata
    - Implement integrity checks for tool definitions

14. **Dynamic Execution Monitoring**: Monitor runtime behavior of MCP servers and tools.
    - Use behavioral analysis to detect anomalies
    - Set up alerts for unexpected execution patterns
    - Employ runtime application self-protection (RASP) techniques

15. **Principle of Least Privilege**: Ensure MCP servers and tools operate with the minimum permissions necessary.
    - Grant only the permissions required for each operation
    - Regularly review and audit permission usage
    - Implement just-in-time access for administrative functions

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.