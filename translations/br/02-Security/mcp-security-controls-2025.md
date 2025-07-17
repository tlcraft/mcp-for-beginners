<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T01:50:24+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "br"
}
-->
# Últimas Controles de Segurança do MCP - Atualização de Julho de 2025

À medida que o Model Context Protocol (MCP) continua a evoluir, a segurança permanece uma consideração crítica. Este documento descreve os controles de segurança mais recentes e as melhores práticas para implementar o MCP de forma segura em julho de 2025.

## Autenticação e Autorização

### Suporte à Delegação OAuth 2.0

Atualizações recentes na especificação do MCP agora permitem que servidores MCP deleguem a autenticação de usuários para serviços externos, como o Microsoft Entra ID. Isso melhora significativamente a postura de segurança ao:

1. **Eliminar Implementações Personalizadas de Autenticação**: Reduz o risco de falhas de segurança em códigos de autenticação personalizados  
2. **Aproveitar Provedores de Identidade Consolidados**: Beneficia-se de recursos de segurança em nível empresarial  
3. **Centralizar o Gerenciamento de Identidade**: Simplifica o gerenciamento do ciclo de vida do usuário e o controle de acesso  

## Prevenção de Passagem de Token

A Especificação de Autorização do MCP proíbe explicitamente a passagem de tokens para evitar a violação dos controles de segurança e problemas de responsabilidade.

### Requisitos Principais

1. **Servidores MCP NÃO DEVEM aceitar tokens que não foram emitidos para eles**: Validar que todos os tokens possuam a claim de audiência correta  
2. **Implementar validação adequada de tokens**: Verificar emissor, audiência, expiração e assinatura  
3. **Usar emissão separada de tokens**: Emitir novos tokens para serviços downstream em vez de repassar tokens existentes  

## Gerenciamento Seguro de Sessão

Para evitar sequestro e fixação de sessão, implemente os seguintes controles:

1. **Use IDs de sessão seguros e não determinísticos**: Gerados com geradores de números aleatórios criptograficamente seguros  
2. **Vincule sessões à identidade do usuário**: Combine IDs de sessão com informações específicas do usuário  
3. **Implemente rotação adequada de sessão**: Após mudanças de autenticação ou elevação de privilégios  
4. **Defina tempos de expiração de sessão apropriados**: Equilibre segurança com a experiência do usuário  

## Sandboxing na Execução de Ferramentas

Para evitar movimentação lateral e conter possíveis comprometimentos:

1. **Isole os ambientes de execução das ferramentas**: Use containers ou processos separados  
2. **Aplique limites de recursos**: Prevenir ataques de exaustão de recursos  
3. **Implemente acesso com privilégios mínimos**: Conceda apenas as permissões necessárias  
4. **Monitore padrões de execução**: Detecte comportamentos anômalos  

## Proteção da Definição de Ferramentas

Para evitar envenenamento de ferramentas:

1. **Valide definições de ferramentas antes do uso**: Verifique instruções maliciosas ou padrões inadequados  
2. **Use verificação de integridade**: Faça hash ou assine definições de ferramentas para detectar alterações não autorizadas  
3. **Implemente monitoramento de mudanças**: Alerta sobre modificações inesperadas nos metadados das ferramentas  
4. **Controle de versão das definições de ferramentas**: Acompanhe mudanças e permita rollback se necessário  

Esses controles trabalham juntos para criar uma postura de segurança robusta para implementações MCP, abordando os desafios únicos dos sistemas orientados por IA, enquanto mantêm práticas tradicionais de segurança fortes.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.