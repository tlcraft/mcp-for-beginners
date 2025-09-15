<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:07:30+00:00",
  "source_file": "changelog.md",
  "language_code": "br"
}
-->
# Registro de Alterações: Currículo MCP para Iniciantes

Este documento serve como registro de todas as mudanças significativas feitas no currículo do Protocolo de Contexto de Modelo (MCP) para Iniciantes. As alterações estão documentadas em ordem cronológica inversa (alterações mais recentes primeiro).

## 15 de setembro de 2025

### Expansão de Tópicos Avançados - Transportes Personalizados e Engenharia de Contexto

#### Transportes Personalizados MCP (05-AdvancedTopics/mcp-transport/) - Novo Guia de Implementação Avançada
- **README.md**: Guia completo de implementação para mecanismos de transporte personalizados do MCP
  - **Transporte Azure Event Grid**: Implementação abrangente de transporte sem servidor orientado por eventos
    - Exemplos em C#, TypeScript e Python com integração ao Azure Functions
    - Padrões de arquitetura orientados por eventos para soluções MCP escaláveis
    - Receptores de webhook e manipulação de mensagens baseada em push
  - **Transporte Azure Event Hubs**: Implementação de transporte de streaming de alta capacidade
    - Capacidades de streaming em tempo real para cenários de baixa latência
    - Estratégias de particionamento e gerenciamento de checkpoints
    - Otimização de desempenho e agrupamento de mensagens
  - **Padrões de Integração Empresarial**: Exemplos arquiteturais prontos para produção
    - Processamento MCP distribuído em várias funções do Azure
    - Arquiteturas híbridas de transporte combinando múltiplos tipos de transporte
    - Estratégias de durabilidade, confiabilidade e tratamento de erros de mensagens
  - **Segurança e Monitoramento**: Integração com Azure Key Vault e padrões de observabilidade
    - Autenticação com identidade gerenciada e acesso com privilégios mínimos
    - Telemetria do Application Insights e monitoramento de desempenho
    - Padrões de tolerância a falhas e circuit breakers
  - **Frameworks de Teste**: Estratégias abrangentes de teste para transportes personalizados
    - Testes unitários com doubles de teste e frameworks de mocking
    - Testes de integração com Azure Test Containers
    - Considerações sobre testes de desempenho e carga

#### Engenharia de Contexto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina Emergente de IA
- **README.md**: Exploração abrangente da engenharia de contexto como um campo emergente
  - **Princípios Fundamentais**: Compartilhamento completo de contexto, consciência de decisão de ação e gerenciamento de janela de contexto
  - **Alinhamento ao Protocolo MCP**: Como o design do MCP aborda os desafios da engenharia de contexto
    - Limitações de janela de contexto e estratégias de carregamento progressivo
    - Determinação de relevância e recuperação dinâmica de contexto
    - Manipulação de contexto multimodal e considerações de segurança
  - **Abordagens de Implementação**: Arquiteturas single-threaded vs. multi-agente
    - Técnicas de fragmentação e priorização de contexto
    - Estratégias de carregamento progressivo e compressão de contexto
    - Abordagens em camadas e otimização de recuperação de contexto
  - **Framework de Medição**: Métricas emergentes para avaliação da eficácia do contexto
    - Eficiência de entrada, desempenho, qualidade e considerações de experiência do usuário
    - Abordagens experimentais para otimização de contexto
    - Análise de falhas e metodologias de melhoria

#### Atualizações de Navegação do Currículo (README.md)
- **Estrutura de Módulos Aprimorada**: Tabela do currículo atualizada para incluir novos tópicos avançados
  - Adicionados Engenharia de Contexto (5.14) e Transporte Personalizado (5.15)
  - Formatação consistente e links de navegação em todos os módulos
  - Descrições atualizadas para refletir o escopo atual do conteúdo

### Melhorias na Estrutura de Diretórios
- **Padronização de Nomes**: Renomeado "mcp transport" para "mcp-transport" para consistência com outras pastas de tópicos avançados
- **Organização de Conteúdo**: Todas as pastas 05-AdvancedTopics agora seguem um padrão de nomenclatura consistente (mcp-[tópico])

### Melhorias na Qualidade da Documentação
- **Alinhamento à Especificação MCP**: Todo o novo conteúdo faz referência à Especificação MCP atual 2025-06-18
- **Exemplos Multilíngues**: Exemplos de código abrangentes em C#, TypeScript e Python
- **Foco Empresarial**: Padrões prontos para produção e integração com a nuvem Azure em todo o conteúdo
- **Documentação Visual**: Diagramas Mermaid para visualização de arquitetura e fluxos

## 18 de agosto de 2025

### Atualização Abrangente da Documentação - Padrões MCP 2025-06-18

#### Melhores Práticas de Segurança MCP (02-Security/) - Modernização Completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescrita completa alinhada à Especificação MCP 2025-06-18
  - **Requisitos Obrigatórios**: Adicionados requisitos explícitos MUST/MUST NOT da especificação oficial com indicadores visuais claros
  - **12 Práticas Fundamentais de Segurança**: Reestruturadas de uma lista de 15 itens para domínios abrangentes de segurança
    - Segurança de Tokens e Autenticação com integração de provedores de identidade externos
    - Gerenciamento de Sessões e Segurança de Transporte com requisitos criptográficos
    - Proteção contra Ameaças Específicas de IA com integração ao Microsoft Prompt Shields
    - Controle de Acesso e Permissões com princípio de menor privilégio
    - Segurança de Conteúdo e Monitoramento com integração ao Azure Content Safety
    - Segurança da Cadeia de Suprimentos com verificação abrangente de componentes
    - Segurança OAuth e Prevenção de Ataques Confused Deputy com implementação PKCE
    - Resposta a Incidentes e Recuperação com capacidades automatizadas
    - Conformidade e Governança com alinhamento regulatório
    - Controles Avançados de Segurança com arquitetura de confiança zero
    - Integração ao Ecossistema de Segurança Microsoft com soluções abrangentes
    - Evolução Contínua de Segurança com práticas adaptativas
  - **Soluções de Segurança Microsoft**: Orientação aprimorada para integração com Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Recursos de Implementação**: Links de recursos abrangentes categorizados por Documentação Oficial MCP, Soluções de Segurança Microsoft, Padrões de Segurança e Guias de Implementação

#### Controles Avançados de Segurança (02-Security/) - Implementação Empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisão completa com framework de segurança empresarial
  - **9 Domínios Abrangentes de Segurança**: Expandido de controles básicos para framework detalhado empresarial
    - Autenticação e Autorização Avançadas com integração ao Microsoft Entra ID
    - Segurança de Tokens e Controles Anti-Passthrough com validação abrangente
    - Controles de Segurança de Sessão com prevenção de sequestro
    - Controles Específicos de IA com prevenção de injeção de prompts e envenenamento de ferramentas
    - Prevenção de Ataques Confused Deputy com segurança de proxy OAuth
    - Segurança na Execução de Ferramentas com sandboxing e isolamento
    - Controles de Segurança da Cadeia de Suprimentos com verificação de dependências
    - Controles de Monitoramento e Detecção com integração SIEM
    - Resposta a Incidentes e Recuperação com capacidades automatizadas
  - **Exemplos de Implementação**: Adicionados blocos de configuração YAML detalhados e exemplos de código
  - **Integração com Soluções Microsoft**: Cobertura abrangente dos serviços de segurança Azure, GitHub Advanced Security e gerenciamento de identidade empresarial

#### Segurança de Tópicos Avançados (05-AdvancedTopics/mcp-security/) - Implementação Pronta para Produção
- **README.md**: Reescrita completa para implementação de segurança empresarial
  - **Alinhamento à Especificação Atual**: Atualizado para Especificação MCP 2025-06-18 com requisitos obrigatórios de segurança
  - **Autenticação Aprimorada**: Integração ao Microsoft Entra ID com exemplos abrangentes em .NET e Java Spring Security
  - **Integração de Segurança de IA**: Implementação do Microsoft Prompt Shields e Azure Content Safety com exemplos detalhados em Python
  - **Mitigação Avançada de Ameaças**: Exemplos abrangentes de implementação para
    - Prevenção de Ataques Confused Deputy com PKCE e validação de consentimento do usuário
    - Prevenção de Passagem de Tokens com validação de público e gerenciamento seguro de tokens
    - Prevenção de Sequestro de Sessão com vinculação criptográfica e análise comportamental
  - **Integração de Segurança Empresarial**: Monitoramento do Azure Application Insights, pipelines de detecção de ameaças e segurança da cadeia de suprimentos
  - **Checklist de Implementação**: Controles de segurança obrigatórios vs. recomendados com benefícios do ecossistema de segurança Microsoft

### Melhorias na Qualidade e Alinhamento da Documentação
- **Referências à Especificação**: Atualizadas todas as referências para a Especificação MCP atual 2025-06-18
- **Ecossistema de Segurança Microsoft**: Orientação aprimorada de integração em toda a documentação de segurança
- **Implementação Prática**: Adicionados exemplos detalhados de código em .NET, Java e Python com padrões empresariais
- **Organização de Recursos**: Categorização abrangente de documentação oficial, padrões de segurança e guias de implementação
- **Indicadores Visuais**: Marcação clara de requisitos obrigatórios vs. práticas recomendadas

#### Conceitos Fundamentais (01-CoreConcepts/) - Modernização Completa
- **Atualização de Versão do Protocolo**: Atualizado para referência à Especificação MCP atual 2025-06-18 com versionamento baseado em data (formato YYYY-MM-DD)
- **Refinamento de Arquitetura**: Descrições aprimoradas de Hosts, Clientes e Servidores para refletir padrões atuais de arquitetura MCP
  - Hosts agora claramente definidos como aplicativos de IA coordenando múltiplas conexões de clientes MCP
  - Clientes descritos como conectores de protocolo mantendo relações um-para-um com servidores
  - Servidores aprimorados com cenários de implantação local vs. remota
- **Reestruturação de Primitivas**: Revisão completa das primitivas de servidor e cliente
  - Primitivas de Servidor: Recursos (fontes de dados), Prompts (templates), Ferramentas (funções executáveis) com explicações detalhadas e exemplos
  - Primitivas de Cliente: Amostragem (completions de LLM), Elicitação (entrada do usuário), Logging (debug/monitoramento)
  - Atualizado com padrões atuais de descoberta (`*/list`), recuperação (`*/get`) e execução (`*/call`)
- **Arquitetura do Protocolo**: Introdução ao modelo de arquitetura em duas camadas
  - Camada de Dados: Fundação JSON-RPC 2.0 com gerenciamento de ciclo de vida e primitivas
  - Camada de Transporte: STDIO (local) e HTTP Streamable com SSE (remoto)
- **Framework de Segurança**: Princípios abrangentes de segurança incluindo consentimento explícito do usuário, proteção de privacidade de dados, segurança na execução de ferramentas e segurança na camada de transporte
- **Padrões de Comunicação**: Mensagens de protocolo atualizadas para mostrar fluxos de inicialização, descoberta, execução e notificação
- **Exemplos de Código**: Exemplos multilíngues atualizados (.NET, Java, Python, JavaScript) para refletir padrões atuais do SDK MCP

#### Segurança (02-Security/) - Revisão Abrangente de Segurança  
- **Alinhamento de Padrões**: Alinhamento completo com os requisitos de segurança da Especificação MCP 2025-06-18
- **Evolução da Autenticação**: Documentada evolução de servidores OAuth personalizados para delegação de provedores de identidade externos (Microsoft Entra ID)
- **Análise de Ameaças Específicas de IA**: Cobertura aprimorada de vetores modernos de ataque de IA
  - Cenários detalhados de ataques de injeção de prompts com exemplos reais
  - Mecanismos de envenenamento de ferramentas e padrões de ataque "rug pull"
  - Envenenamento de janela de contexto e ataques de confusão de modelo
- **Soluções de Segurança de IA Microsoft**: Cobertura abrangente do ecossistema de segurança Microsoft
  - Prompt Shields de IA com técnicas avançadas de detecção, spotlighting e delimitadores
  - Padrões de integração ao Azure Content Safety
  - GitHub Advanced Security para proteção da cadeia de suprimentos
- **Mitigação Avançada de Ameaças**: Controles de segurança detalhados para
  - Sequestro de sessão com cenários de ataque específicos do MCP e requisitos de ID de sessão criptográfica
  - Problemas de Confused Deputy em cenários de proxy MCP com requisitos explícitos de consentimento
  - Vulnerabilidades de passagem de tokens com controles obrigatórios de validação
- **Segurança da Cadeia de Suprimentos**: Cobertura expandida da cadeia de suprimentos de IA incluindo modelos fundacionais, serviços de embeddings, provedores de contexto e APIs de terceiros
- **Segurança Fundamental**: Integração aprimorada com padrões de segurança empresarial incluindo arquitetura de confiança zero e ecossistema de segurança Microsoft
- **Organização de Recursos**: Links de recursos abrangentes categorizados por tipo (Documentação Oficial, Padrões, Pesquisa, Soluções Microsoft, Guias de Implementação)

### Melhorias na Qualidade da Documentação
- **Objetivos de Aprendizado Estruturados**: Objetivos de aprendizado aprimorados com resultados específicos e acionáveis 
- **Referências Cruzadas**: Adicionados links entre tópicos relacionados de segurança e conceitos fundamentais
- **Informações Atualizadas**: Atualizadas todas as referências de datas e links de especificação para padrões atuais
- **Orientação de Implementação**: Adicionadas diretrizes específicas e acionáveis de implementação em ambas as seções

## 16 de julho de 2025

### Melhorias no README e Navegação
- Redesenho completo da navegação do currículo no README.md
- Substituídos tags `<details>` por formato baseado em tabela mais acessível
- Criadas opções de layout alternativo na nova pasta "alternative_layouts"
- Adicionados exemplos de navegação em estilo de cartões, abas e acordeão
- Atualizada seção de estrutura do repositório para incluir todos os arquivos mais recentes
- Aprimorada seção "Como Usar Este Currículo" com recomendações claras
- Atualizados links de especificação MCP para apontar para URLs corretos
- Adicionada seção de Engenharia de Contexto (5.14) à estrutura do currículo

### Atualizações do Guia de Estudos
- Revisão completa do guia de estudos para alinhar com a estrutura atual do repositório
- Adicionadas novas seções para Clientes e Ferramentas MCP, e Servidores MCP Populares
- Atualizado o Mapa Visual do Currículo para refletir com precisão todos os tópicos
- Descrições aprimoradas de Tópicos Avançados para cobrir todas as áreas especializadas
- Atualizada seção de Estudos de Caso para refletir exemplos reais
- Adicionado este registro de alterações abrangente

### Contribuições da Comunidade (06-CommunityContributions/)
- Adicionadas informações detalhadas sobre servidores MCP para geração de imagens
- Adicionada seção abrangente sobre uso do Claude no VSCode
- Adicionadas instruções de configuração e uso do cliente terminal Cline
- Atualizada seção de clientes MCP para incluir todas as opções populares de clientes
- Exemplos de contribuição aprimorados com amostras de código mais precisas

### Tópicos Avançados (05-AdvancedTopics/)
- Organizadas todas as pastas de tópicos especializados com nomenclatura consistente
- Adicionados materiais e exemplos de engenharia de contexto
- Adicionada documentação de integração de agentes Foundry
- Documentação de integração de segurança Entra ID aprimorada

## 11 de junho de 2025

### Criação Inicial
- Lançada a primeira versão do currículo MCP para Iniciantes
- Criada estrutura básica para todas as 10 seções principais
- Implementado Mapa Visual do Currículo para navegação
- Adicionados projetos de exemplo iniciais em múltiplas linguagens de programação

### Primeiros Passos (03-GettingStarted/)
- Criados primeiros exemplos de implementação de servidor
- Adicionada orientação para desenvolvimento de clientes
- Incluídas instruções de integração de clientes LLM
- Adicionada documentação de integração ao VS Code
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
- Desenvolvido framework conceitual para exemplos e estudos de caso
- Criados exemplos de protótipo iniciais para conceitos-chave

---

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.