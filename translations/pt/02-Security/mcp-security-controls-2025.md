<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-16T23:06:00+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "pt"
}
-->
# Controlo de Segurança MCP Mais Recente - Atualização de Julho de 2025

À medida que o Model Context Protocol (MCP) continua a evoluir, a segurança mantém-se uma consideração crítica. Este documento descreve os controlos de segurança mais recentes e as melhores práticas para implementar o MCP de forma segura a partir de julho de 2025.

## Autenticação e Autorização

### Suporte à Delegação OAuth 2.0

As atualizações recentes na especificação MCP permitem agora que os servidores MCP deleguem a autenticação de utilizadores a serviços externos, como o Microsoft Entra ID. Isto melhora significativamente a postura de segurança ao:

1. **Eliminar Implementações Personalizadas de Autenticação**: Reduz o risco de falhas de segurança em código de autenticação personalizado  
2. **Aproveitar Provedores de Identidade Estabelecidos**: Beneficia de funcionalidades de segurança ao nível empresarial  
3. **Centralizar a Gestão de Identidade**: Simplifica a gestão do ciclo de vida do utilizador e o controlo de acesso  

## Prevenção de Passagem de Token

A Especificação de Autorização MCP proíbe explicitamente a passagem de tokens para evitar a contornação dos controlos de segurança e problemas de responsabilidade.

### Requisitos Principais

1. **Os servidores MCP NÃO DEVEM aceitar tokens que não lhes sejam destinados**: Validar que todos os tokens têm a claim de audiência correta  
2. **Implementar validação adequada dos tokens**: Verificar emissor, audiência, expiração e assinatura  
3. **Usar emissão de tokens separada**: Emitir novos tokens para serviços a jusante em vez de passar tokens existentes  

## Gestão Segura de Sessões

Para prevenir ataques de sequestro e fixação de sessão, implemente os seguintes controlos:

1. **Usar IDs de sessão seguros e não determinísticos**: Gerados com geradores de números aleatórios criptograficamente seguros  
2. **Associar sessões à identidade do utilizador**: Combinar IDs de sessão com informação específica do utilizador  
3. **Implementar rotação adequada de sessões**: Após alterações de autenticação ou escalonamento de privilégios  
4. **Definir tempos de expiração de sessão apropriados**: Equilibrar segurança com experiência do utilizador  

## Isolamento da Execução de Ferramentas

Para prevenir movimentos laterais e conter potenciais compromissos:

1. **Isolar ambientes de execução das ferramentas**: Usar contentores ou processos separados  
2. **Aplicar limites de recursos**: Prevenir ataques de exaustão de recursos  
3. **Implementar acesso com privilégios mínimos**: Conceder apenas as permissões necessárias  
4. **Monitorizar padrões de execução**: Detetar comportamentos anómalos  

## Proteção da Definição de Ferramentas

Para evitar envenenamento de ferramentas:

1. **Validar definições de ferramentas antes da utilização**: Verificar instruções maliciosas ou padrões inadequados  
2. **Usar verificação de integridade**: Hash ou assinatura das definições para detetar alterações não autorizadas  
3. **Implementar monitorização de alterações**: Alertar sobre modificações inesperadas nos metadados das ferramentas  
4. **Controlar versões das definições de ferramentas**: Rastrear alterações e permitir reversão se necessário  

Estes controlos funcionam em conjunto para criar uma postura de segurança robusta para implementações MCP, abordando os desafios únicos dos sistemas orientados por IA, ao mesmo tempo que mantêm práticas tradicionais de segurança sólidas.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.