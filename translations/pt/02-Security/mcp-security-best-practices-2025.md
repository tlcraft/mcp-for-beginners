<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-16T23:11:26+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "pt"
}
-->
# Práticas Recomendadas de Segurança MCP - Atualização de Julho de 2025

## Práticas Abrangentes de Segurança para Implementações MCP

Ao trabalhar com servidores MCP, siga estas práticas recomendadas de segurança para proteger os seus dados, infraestrutura e utilizadores:

1. **Validação de Entrada**: Valide e sanitize sempre as entradas para evitar ataques de injeção e problemas de delegado confuso.
   - Implemente validação rigorosa para todos os parâmetros das ferramentas
   - Utilize validação de esquema para garantir que os pedidos estão no formato esperado
   - Filtre conteúdos potencialmente maliciosos antes do processamento

2. **Controlo de Acesso**: Implemente autenticação e autorização adequadas para o seu servidor MCP com permissões granulares.
   - Utilize OAuth 2.0 com provedores de identidade estabelecidos como o Microsoft Entra ID
   - Implemente controlo de acesso baseado em funções (RBAC) para as ferramentas MCP
   - Nunca implemente autenticação personalizada quando existirem soluções consolidadas

3. **Comunicação Segura**: Utilize HTTPS/TLS para todas as comunicações com o seu servidor MCP e considere adicionar encriptação adicional para dados sensíveis.
   - Configure TLS 1.3 sempre que possível
   - Implemente certificate pinning para ligações críticas
   - Rode regularmente os certificados e verifique a sua validade

4. **Limitação de Taxa**: Implemente limitação de taxa para prevenir abusos, ataques DoS e gerir o consumo de recursos.
   - Defina limites de pedidos adequados com base nos padrões de uso esperados
   - Implemente respostas graduadas para pedidos excessivos
   - Considere limites de taxa específicos por utilizador com base no estado de autenticação

5. **Registo e Monitorização**: Monitorize o seu servidor MCP para atividades suspeitas e implemente registos de auditoria abrangentes.
   - Registe todas as tentativas de autenticação e invocações de ferramentas
   - Implemente alertas em tempo real para padrões suspeitos
   - Garanta que os registos são armazenados de forma segura e não podem ser alterados

6. **Armazenamento Seguro**: Proteja dados sensíveis e credenciais com encriptação adequada em repouso.
   - Utilize cofres de chaves ou armazenamentos seguros para todos os segredos
   - Implemente encriptação ao nível de campo para dados sensíveis
   - Rode regularmente as chaves de encriptação e credenciais

7. **Gestão de Tokens**: Previna vulnerabilidades de passagem de tokens validando e sanitizando todas as entradas e saídas do modelo.
   - Implemente validação de tokens com base nas claims de audiência
   - Nunca aceite tokens que não tenham sido explicitamente emitidos para o seu servidor MCP
   - Implemente gestão adequada do tempo de vida dos tokens e rotação

8. **Gestão de Sessões**: Implemente gestão segura de sessões para prevenir sequestro e fixação de sessões.
   - Utilize IDs de sessão seguros e não determinísticos
   - Associe sessões a informações específicas do utilizador
   - Implemente expiração e rotação adequadas das sessões

9. **Sandboxing da Execução de Ferramentas**: Execute as ferramentas em ambientes isolados para evitar movimentos laterais em caso de comprometimento.
   - Implemente isolamento por containers para a execução das ferramentas
   - Aplique limites de recursos para prevenir ataques de exaustão de recursos
   - Utilize contextos de execução separados para diferentes domínios de segurança

10. **Auditorias de Segurança Regulares**: Realize revisões periódicas de segurança das suas implementações MCP e dependências.
    - Agende testes de penetração regulares
    - Utilize ferramentas de análise automatizadas para detetar vulnerabilidades
    - Mantenha as dependências atualizadas para resolver problemas de segurança conhecidos

11. **Filtragem de Segurança de Conteúdo**: Implemente filtros de segurança de conteúdo tanto para entradas como para saídas.
    - Utilize Azure Content Safety ou serviços similares para detetar conteúdos nocivos
    - Implemente técnicas de proteção de prompt para evitar injeção de prompt
    - Analise o conteúdo gerado para possíveis fugas de dados sensíveis

12. **Segurança da Cadeia de Abastecimento**: Verifique a integridade e autenticidade de todos os componentes na sua cadeia de abastecimento de IA.
    - Utilize pacotes assinados e verifique as assinaturas
    - Implemente análise de software bill of materials (SBOM)
    - Monitorize atualizações maliciosas nas dependências

13. **Proteção da Definição de Ferramentas**: Previna envenenamento de ferramentas protegendo definições e metadados.
    - Valide as definições das ferramentas antes da utilização
    - Monitorize alterações inesperadas nos metadados das ferramentas
    - Implemente verificações de integridade para as definições das ferramentas

14. **Monitorização Dinâmica da Execução**: Monitorize o comportamento em tempo de execução dos servidores e ferramentas MCP.
    - Implemente análise comportamental para detetar anomalias
    - Configure alertas para padrões de execução inesperados
    - Utilize técnicas de runtime application self-protection (RASP)

15. **Princípio do Menor Privilégio**: Assegure que os servidores e ferramentas MCP operam com as permissões mínimas necessárias.
    - Conceda apenas as permissões específicas necessárias para cada operação
    - Reveja e audite regularmente a utilização das permissões
    - Implemente acesso just-in-time para funções administrativas

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos por garantir a precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.