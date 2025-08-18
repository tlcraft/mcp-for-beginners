<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T16:59:46+00:00",
  "source_file": "changelog.md",
  "language_code": "br"
}
-->
# Registro de Alterações: Currículo MCP para Iniciantes

Este documento serve como um registro de todas as mudanças significativas feitas no currículo do Protocolo de Contexto de Modelo (MCP) para Iniciantes. As alterações são documentadas em ordem cronológica inversa (alterações mais recentes primeiro).

## 18 de agosto de 2025

### Atualização Abrangente da Documentação - Padrões MCP 2025-06-18

#### Práticas de Segurança do MCP (02-Security/) - Modernização Completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescrita completa alinhada à Especificação MCP 2025-06-18
  - **Requisitos Obrigatórios**: Adicionados requisitos explícitos de MUST/MUST NOT da especificação oficial com indicadores visuais claros
  - **12 Práticas de Segurança Essenciais**: Reestruturadas de uma lista de 15 itens para domínios de segurança abrangentes
    - Segurança de Tokens e Autenticação com integração de provedores de identidade externos
    - Gerenciamento de Sessões e Segurança de Transporte com requisitos criptográficos
    - Proteção contra Ameaças Específicas de IA com integração do Microsoft Prompt Shields
    - Controle de Acesso e Permissões com o princípio do menor privilégio
    - Segurança e Monitoramento de Conteúdo com integração do Azure Content Safety
    - Segurança da Cadeia de Suprimentos com verificação abrangente de componentes
    - Segurança OAuth e Prevenção de Ataques Confused Deputy com implementação de PKCE
    - Resposta e Recuperação de Incidentes com capacidades automatizadas
    - Conformidade e Governança com alinhamento regulatório
    - Controles de Segurança Avançados com arquitetura de confiança zero
    - Integração com o Ecossistema de Segurança da Microsoft com soluções abrangentes
    - Evolução Contínua da Segurança com práticas adaptativas
  - **Soluções de Segurança da Microsoft**: Orientação aprimorada para integração do Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Recursos de Implementação**: Links de recursos abrangentes categorizados por Documentação Oficial do MCP, Soluções de Segurança da Microsoft, Padrões de Segurança e Guias de Implementação

#### Controles de Segurança Avançados (02-Security/) - Implementação Empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisão completa com estrutura de segurança de nível empresarial
  - **9 Domínios de Segurança Abrangentes**: Expandido de controles básicos para uma estrutura empresarial detalhada
    - Autenticação e Autorização Avançadas com integração do Microsoft Entra ID
    - Segurança de Tokens e Controles Anti-Passthrough com validação abrangente
    - Controles de Segurança de Sessão com prevenção de sequestro
    - Controles de Segurança Específicos de IA com prevenção de injeção de prompts e envenenamento de ferramentas
    - Prevenção de Ataques Confused Deputy com segurança de proxy OAuth
    - Segurança na Execução de Ferramentas com sandboxing e isolamento
    - Controles de Segurança da Cadeia de Suprimentos com verificação de dependências
    - Controles de Monitoramento e Detecção com integração de SIEM
    - Resposta e Recuperação de Incidentes com capacidades automatizadas
  - **Exemplos de Implementação**: Adicionados blocos de configuração YAML detalhados e exemplos de código
  - **Integração com Soluções da Microsoft**: Cobertura abrangente dos serviços de segurança do Azure, GitHub Advanced Security e gerenciamento de identidade empresarial

#### Tópicos Avançados de Segurança (05-AdvancedTopics/mcp-security/) - Implementação Pronta para Produção
- **README.md**: Reescrita completa para implementação de segurança empresarial
  - **Alinhamento com a Especificação Atual**: Atualizado para a Especificação MCP 2025-06-18 com requisitos obrigatórios de segurança
  - **Autenticação Aprimorada**: Integração do Microsoft Entra ID com exemplos abrangentes em .NET e Java Spring Security
  - **Integração de Segurança de IA**: Implementação do Microsoft Prompt Shields e Azure Content Safety com exemplos detalhados em Python
  - **Mitigação Avançada de Ameaças**: Exemplos abrangentes de implementação para
    - Prevenção de Ataques Confused Deputy com PKCE e validação de consentimento do usuário
    - Prevenção de Passagem de Tokens com validação de público e gerenciamento seguro de tokens
    - Prevenção de Sequestro de Sessão com vinculação criptográfica e análise comportamental
  - **Integração de Segurança Empresarial**: Monitoramento do Azure Application Insights, pipelines de detecção de ameaças e segurança da cadeia de suprimentos
  - **Lista de Verificação de Implementação**: Controles de segurança obrigatórios vs. recomendados com benefícios do ecossistema de segurança da Microsoft

### Qualidade da Documentação e Alinhamento com Padrões
- **Referências à Especificação**: Atualizadas todas as referências para a Especificação MCP 2025-06-18 atual
- **Ecossistema de Segurança da Microsoft**: Orientação aprimorada de integração em toda a documentação de segurança
- **Implementação Prática**: Adicionados exemplos detalhados de código em .NET, Java e Python com padrões empresariais
- **Organização de Recursos**: Categorização abrangente de documentação oficial, padrões de segurança e guias de implementação
- **Indicadores Visuais**: Marcação clara de requisitos obrigatórios vs. práticas recomendadas

#### Conceitos Fundamentais (01-CoreConcepts/) - Modernização Completa
- **Atualização da Versão do Protocolo**: Atualizado para referência à Especificação MCP 2025-06-18 com versionamento baseado em data (formato YYYY-MM-DD)
- **Refinamento da Arquitetura**: Descrições aprimoradas de Hosts, Clientes e Servidores para refletir os padrões atuais de arquitetura MCP
  - Hosts agora definidos claramente como aplicativos de IA coordenando múltiplas conexões de clientes MCP
  - Clientes descritos como conectores de protocolo mantendo relações um-para-um com servidores
  - Servidores aprimorados com cenários de implantação local vs. remota
- **Reestruturação de Primitivas**: Revisão completa das primitivas de servidor e cliente
  - Primitivas de Servidor: Recursos (fontes de dados), Prompts (modelos), Ferramentas (funções executáveis) com explicações detalhadas e exemplos
  - Primitivas de Cliente: Amostragem (completions de LLM), Elicitação (entrada do usuário), Registro (depuração/monitoramento)
  - Atualizado com padrões atuais de descoberta (`*/list`), recuperação (`*/get`) e execução (`*/call`)
- **Arquitetura do Protocolo**: Introduzido modelo de arquitetura de duas camadas
  - Camada de Dados: Fundação JSON-RPC 2.0 com gerenciamento de ciclo de vida e primitivas
  - Camada de Transporte: STDIO (local) e HTTP com SSE (remoto) como mecanismos de transporte
- **Estrutura de Segurança**: Princípios de segurança abrangentes incluindo consentimento explícito do usuário, proteção de privacidade de dados, segurança na execução de ferramentas e segurança na camada de transporte
- **Padrões de Comunicação**: Mensagens do protocolo atualizadas para mostrar fluxos de inicialização, descoberta, execução e notificação
- **Exemplos de Código**: Exemplos multilíngues atualizados (.NET, Java, Python, JavaScript) para refletir os padrões atuais do SDK MCP

#### Segurança (02-Security/) - Revisão Abrangente de Segurança  
- **Alinhamento com Padrões**: Alinhamento completo com os requisitos de segurança da Especificação MCP 2025-06-18
- **Evolução da Autenticação**: Documentada a evolução de servidores OAuth personalizados para delegação de provedores de identidade externos (Microsoft Entra ID)
- **Análise de Ameaças Específicas de IA**: Cobertura aprimorada de vetores modernos de ataque de IA
  - Cenários detalhados de ataques de injeção de prompts com exemplos do mundo real
  - Mecanismos de envenenamento de ferramentas e padrões de ataque "rug pull"
  - Envenenamento de janelas de contexto e ataques de confusão de modelo
- **Soluções de Segurança de IA da Microsoft**: Cobertura abrangente do ecossistema de segurança da Microsoft
  - Prompt Shields de IA com técnicas avançadas de detecção, destaque e delimitadores
  - Padrões de integração do Azure Content Safety
  - GitHub Advanced Security para proteção da cadeia de suprimentos
- **Mitigação Avançada de Ameaças**: Controles de segurança detalhados para
  - Sequestro de sessão com cenários de ataque específicos do MCP e requisitos de ID de sessão criptográficos
  - Problemas de Confused Deputy em cenários de proxy MCP com requisitos explícitos de consentimento
  - Vulnerabilidades de passagem de tokens com controles obrigatórios de validação
- **Segurança da Cadeia de Suprimentos**: Cobertura expandida da cadeia de suprimentos de IA incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros
- **Segurança Fundamental**: Integração aprimorada com padrões de segurança empresarial incluindo arquitetura de confiança zero e ecossistema de segurança da Microsoft
- **Organização de Recursos**: Links de recursos abrangentes categorizados por tipo (Documentos Oficiais, Padrões, Pesquisa, Soluções da Microsoft, Guias de Implementação)

### Melhorias na Qualidade da Documentação
- **Objetivos de Aprendizado Estruturados**: Objetivos de aprendizado aprimorados com resultados específicos e acionáveis
- **Referências Cruzadas**: Adicionados links entre tópicos relacionados de segurança e conceitos fundamentais
- **Informações Atualizadas**: Atualizadas todas as referências de datas e links de especificação para padrões atuais
- **Orientação de Implementação**: Adicionadas diretrizes específicas e acionáveis de implementação em todas as seções

## 16 de julho de 2025

### Melhorias no README e Navegação
- Redesenho completo da navegação do currículo no README.md
- Substituídos os tags `<details>` por formato baseado em tabelas mais acessível
- Criadas opções de layout alternativo na nova pasta "alternative_layouts"
- Adicionados exemplos de navegação em estilo de cartões, abas e acordeão
- Atualizada a seção de estrutura do repositório para incluir todos os arquivos mais recentes
- Melhorada a seção "Como Usar Este Currículo" com recomendações claras
- Atualizados os links de especificação do MCP para apontar para URLs corretos
- Adicionada seção de Engenharia de Contexto (5.14) à estrutura do currículo

### Atualizações do Guia de Estudos
- Revisão completa do guia de estudos para alinhar com a estrutura atual do repositório
- Adicionadas novas seções para Clientes e Ferramentas MCP e Servidores MCP Populares
- Atualizado o Mapa Visual do Currículo para refletir com precisão todos os tópicos
- Melhoradas as descrições de Tópicos Avançados para cobrir todas as áreas especializadas
- Atualizada a seção de Estudos de Caso para refletir exemplos reais
- Adicionado este registro de alterações abrangente

### Contribuições da Comunidade (06-CommunityContributions/)
- Adicionadas informações detalhadas sobre servidores MCP para geração de imagens
- Adicionada seção abrangente sobre o uso do Claude no VSCode
- Adicionadas instruções de configuração e uso do cliente terminal Cline
- Atualizada a seção de clientes MCP para incluir todas as opções populares de clientes
- Melhorados os exemplos de contribuição com amostras de código mais precisas

### Tópicos Avançados (05-AdvancedTopics/)
- Organizadas todas as pastas de tópicos especializados com nomenclatura consistente
- Adicionados materiais e exemplos de engenharia de contexto
- Adicionada documentação de integração do agente Foundry
- Melhorada a documentação de integração de segurança do Entra ID

## 11 de junho de 2025

### Criação Inicial
- Lançada a primeira versão do currículo MCP para Iniciantes
- Criada estrutura básica para todas as 10 seções principais
- Implementado Mapa Visual do Currículo para navegação
- Adicionados projetos de exemplo iniciais em múltiplas linguagens de programação

### Primeiros Passos (03-GettingStarted/)
- Criados os primeiros exemplos de implementação de servidor
- Adicionada orientação para desenvolvimento de clientes
- Incluídas instruções de integração de clientes LLM
- Adicionada documentação de integração com VS Code
- Implementados exemplos de servidor com Server-Sent Events (SSE)

### Conceitos Fundamentais (01-CoreConcepts/)
- Adicionada explicação detalhada da arquitetura cliente-servidor
- Criada documentação sobre componentes-chave do protocolo
- Documentados padrões de mensagens no MCP

## 23 de maio de 2025

### Estrutura do Repositório
- Inicializado o repositório com estrutura básica de pastas
- Criados arquivos README para cada seção principal
- Configurada infraestrutura de tradução
- Adicionados ativos de imagem e diagramas

### Documentação
- Criado README.md inicial com visão geral do currículo
- Adicionados CODE_OF_CONDUCT.md e SECURITY.md
- Configurado SUPPORT.md com orientações para obter ajuda
- Criada estrutura preliminar do guia de estudos

## 15 de abril de 2025

### Planejamento e Estrutura
- Planejamento inicial para o currículo MCP para Iniciantes
- Definidos objetivos de aprendizado e público-alvo
- Estruturadas 10 seções do currículo
- Desenvolvida estrutura conceitual para exemplos e estudos de caso
- Criados protótipos iniciais de exemplos para conceitos-chave

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.