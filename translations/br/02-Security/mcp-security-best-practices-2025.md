<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T01:57:20+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "br"
}
-->
# Práticas Recomendadas de Segurança MCP - Atualização Julho 2025

## Práticas Abrangentes de Segurança para Implementações MCP

Ao trabalhar com servidores MCP, siga estas práticas recomendadas de segurança para proteger seus dados, infraestrutura e usuários:

1. **Validação de Entrada**: Sempre valide e sanitize as entradas para evitar ataques de injeção e problemas de delegado confuso.
   - Implemente validação rigorosa para todos os parâmetros das ferramentas
   - Use validação de esquema para garantir que as requisições estejam no formato esperado
   - Filtre conteúdos potencialmente maliciosos antes do processamento

2. **Controle de Acesso**: Implemente autenticação e autorização adequadas para seu servidor MCP com permissões granulares.
   - Use OAuth 2.0 com provedores de identidade estabelecidos como Microsoft Entra ID
   - Implemente controle de acesso baseado em função (RBAC) para as ferramentas MCP
   - Nunca implemente autenticação personalizada quando soluções consolidadas já existem

3. **Comunicação Segura**: Use HTTPS/TLS para todas as comunicações com seu servidor MCP e considere adicionar criptografia extra para dados sensíveis.
   - Configure TLS 1.3 sempre que possível
   - Implemente certificate pinning para conexões críticas
   - Faça a rotação regular dos certificados e verifique sua validade

4. **Limitação de Taxa**: Implemente limitação de taxa para evitar abusos, ataques DoS e gerenciar o consumo de recursos.
   - Defina limites adequados de requisições com base nos padrões esperados de uso
   - Implemente respostas graduadas para requisições excessivas
   - Considere limites de taxa específicos para usuários conforme o status de autenticação

5. **Registro e Monitoramento**: Monitore seu servidor MCP para atividades suspeitas e implemente trilhas de auditoria completas.
   - Registre todas as tentativas de autenticação e invocações de ferramentas
   - Implemente alertas em tempo real para padrões suspeitos
   - Garanta que os logs sejam armazenados de forma segura e não possam ser alterados

6. **Armazenamento Seguro**: Proteja dados sensíveis e credenciais com criptografia adequada em repouso.
   - Use cofres de chaves ou armazenamentos seguros para todos os segredos
   - Implemente criptografia em nível de campo para dados sensíveis
   - Faça a rotação regular de chaves de criptografia e credenciais

7. **Gerenciamento de Tokens**: Evite vulnerabilidades de passagem de token validando e sanitizando todas as entradas e saídas do modelo.
   - Implemente validação de token baseada nas claims de audiência
   - Nunca aceite tokens que não tenham sido explicitamente emitidos para seu servidor MCP
   - Gerencie corretamente o tempo de vida dos tokens e faça sua rotação

8. **Gerenciamento de Sessão**: Implemente o manuseio seguro de sessões para evitar sequestro e fixação de sessão.
   - Use IDs de sessão seguros e não determinísticos
   - Vincule sessões a informações específicas do usuário
   - Implemente expiração e rotação adequadas das sessões

9. **Sandboxing de Execução de Ferramentas**: Execute as ferramentas em ambientes isolados para evitar movimentação lateral em caso de comprometimento.
   - Implemente isolamento por container para a execução das ferramentas
   - Aplique limites de recursos para evitar ataques de exaustão
   - Use contextos de execução separados para diferentes domínios de segurança

10. **Auditorias de Segurança Regulares**: Realize revisões periódicas de segurança nas suas implementações MCP e dependências.
    - Agende testes de penetração regulares
    - Use ferramentas automatizadas de varredura para detectar vulnerabilidades
    - Mantenha as dependências atualizadas para corrigir problemas de segurança conhecidos

11. **Filtragem de Segurança de Conteúdo**: Implemente filtros de segurança de conteúdo tanto para entradas quanto para saídas.
    - Use Azure Content Safety ou serviços similares para detectar conteúdo nocivo
    - Implemente técnicas de proteção contra injeção de prompt
    - Escaneie o conteúdo gerado para identificar possíveis vazamentos de dados sensíveis

12. **Segurança da Cadeia de Suprimentos**: Verifique a integridade e autenticidade de todos os componentes na sua cadeia de suprimentos de IA.
    - Use pacotes assinados e verifique as assinaturas
    - Implemente análise de bill of materials (SBOM) de software
    - Monitore atualizações maliciosas nas dependências

13. **Proteção da Definição de Ferramentas**: Evite envenenamento de ferramentas protegendo definições e metadados.
    - Valide as definições das ferramentas antes do uso
    - Monitore alterações inesperadas nos metadados das ferramentas
    - Implemente verificações de integridade para as definições das ferramentas

14. **Monitoramento Dinâmico de Execução**: Monitore o comportamento em tempo de execução dos servidores MCP e ferramentas.
    - Implemente análise comportamental para detectar anomalias
    - Configure alertas para padrões de execução inesperados
    - Use técnicas de runtime application self-protection (RASP)

15. **Princípio do Menor Privilégio**: Garanta que servidores MCP e ferramentas operem com as permissões mínimas necessárias.
    - Conceda apenas as permissões específicas necessárias para cada operação
    - Revise e audite regularmente o uso das permissões
    - Implemente acesso just-in-time para funções administrativas

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.