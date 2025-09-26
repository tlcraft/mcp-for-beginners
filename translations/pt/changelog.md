<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:14:09+00:00",
  "source_file": "changelog.md",
  "language_code": "pt"
}
-->
# Registo de Alterações: Currículo MCP para Iniciantes

Este documento serve como registo de todas as alterações significativas feitas ao currículo do Model Context Protocol (MCP) para Iniciantes. As alterações estão documentadas em ordem cronológica inversa (alterações mais recentes primeiro).

## 26 de setembro de 2025

### Melhoria de Estudos de Caso - Integração com o Registo MCP do GitHub

#### Estudos de Caso (09-CaseStudy/) - Foco no Desenvolvimento do Ecossistema
- **README.md**: Expansão significativa com estudo de caso abrangente sobre o Registo MCP do GitHub
  - **Estudo de Caso do Registo MCP do GitHub**: Novo estudo de caso detalhado sobre o lançamento do Registo MCP do GitHub em setembro de 2025
    - **Análise do Problema**: Exame detalhado dos desafios de descoberta e implementação fragmentada de servidores MCP
    - **Arquitetura da Solução**: Abordagem centralizada do registo do GitHub com instalação de um clique no VS Code
    - **Impacto Empresarial**: Melhorias mensuráveis na integração de desenvolvedores e na produtividade
    - **Valor Estratégico**: Foco na implementação modular de agentes e na interoperabilidade entre ferramentas
    - **Desenvolvimento do Ecossistema**: Posicionamento como plataforma fundamental para integração de agentes
  - **Estrutura Melhorada dos Estudos de Caso**: Atualização de todos os sete estudos de caso com formatação consistente e descrições abrangentes
    - Agentes de Viagem Azure AI: Ênfase na orquestração multi-agente
    - Integração Azure DevOps: Foco na automação de fluxos de trabalho
    - Recuperação de Documentação em Tempo Real: Implementação de cliente de consola Python
    - Gerador de Plano de Estudos Interativo: Aplicação web conversacional Chainlit
    - Documentação no Editor: Integração com VS Code e GitHub Copilot
    - Gestão de API Azure: Padrões de integração de API empresarial
    - Registo MCP do GitHub: Desenvolvimento do ecossistema e plataforma comunitária
  - **Conclusão Abrangente**: Reescrita da seção de conclusão destacando os sete estudos de caso que abrangem múltiplas dimensões de implementação do MCP
    - Integração Empresarial, Orquestração Multi-Agente, Produtividade de Desenvolvedores
    - Desenvolvimento do Ecossistema, Aplicações Educacionais
    - Insights melhorados sobre padrões arquiteturais, estratégias de implementação e melhores práticas
    - Ênfase no MCP como protocolo maduro e pronto para produção

#### Atualizações do Guia de Estudos (study_guide.md)
- **Mapa Visual do Currículo**: Atualização do mapa mental para incluir o Registo MCP do GitHub na seção de Estudos de Caso
- **Descrição dos Estudos de Caso**: Melhorada de descrições genéricas para uma análise detalhada dos sete estudos de caso abrangentes
- **Estrutura do Repositório**: Atualização da seção 10 para refletir a cobertura abrangente dos estudos de caso com detalhes específicos de implementação
- **Integração do Registo de Alterações**: Adição da entrada de 26 de setembro de 2025 documentando a adição do Registo MCP do GitHub e as melhorias nos estudos de caso
- **Atualizações de Data**: Atualização do rodapé para refletir a última revisão (26 de setembro de 2025)

### Melhorias na Qualidade da Documentação
- **Melhoria de Consistência**: Padronização da formatação e estrutura dos estudos de caso em todos os sete exemplos
- **Cobertura Abrangente**: Estudos de caso agora abrangem cenários empresariais, de produtividade de desenvolvedores e de desenvolvimento do ecossistema
- **Posicionamento Estratégico**: Foco melhorado no MCP como plataforma fundamental para a implementação de sistemas de agentes
- **Integração de Recursos**: Atualização de recursos adicionais para incluir o link do Registo MCP do GitHub

## 15 de setembro de 2025

### Expansão de Tópicos Avançados - Transportes Personalizados e Engenharia de Contexto

#### Transportes Personalizados MCP (05-AdvancedTopics/mcp-transport/) - Novo Guia de Implementação Avançada
- **README.md**: Guia completo de implementação para mecanismos de transporte personalizados do MCP
  - **Transporte Azure Event Grid**: Implementação abrangente de transporte sem servidor e orientado por eventos
    - Exemplos em C#, TypeScript e Python com integração Azure Functions
    - Padrões de arquitetura orientados por eventos para soluções MCP escaláveis
    - Receptores de webhook e manipulação de mensagens baseada em push
  - **Transporte Azure Event Hubs**: Implementação de transporte de streaming de alta capacidade
    - Capacidades de streaming em tempo real para cenários de baixa latência
    - Estratégias de particionamento e gestão de pontos de verificação
    - Otimização de desempenho e agrupamento de mensagens
  - **Padrões de Integração Empresarial**: Exemplos arquiteturais prontos para produção
    - Processamento MCP distribuído em várias Azure Functions
    - Arquiteturas híbridas de transporte combinando múltiplos tipos de transporte
    - Estratégias de durabilidade, confiabilidade e manipulação de erros
  - **Segurança e Monitorização**: Integração com Azure Key Vault e padrões de observabilidade
    - Autenticação de identidade gerida e acesso com privilégios mínimos
    - Telemetria do Application Insights e monitorização de desempenho
    - Disjuntores e padrões de tolerância a falhas
  - **Frameworks de Teste**: Estratégias abrangentes de teste para transportes personalizados
    - Testes unitários com doubles de teste e frameworks de mocking
    - Testes de integração com Azure Test Containers
    - Considerações sobre testes de desempenho e carga

#### Engenharia de Contexto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina Emergente de IA
- **README.md**: Exploração abrangente da engenharia de contexto como um campo emergente
  - **Princípios Fundamentais**: Partilha completa de contexto, consciência de decisão de ação e gestão de janela de contexto
  - **Alinhamento com o Protocolo MCP**: Como o design do MCP aborda os desafios da engenharia de contexto
    - Limitações de janela de contexto e estratégias de carregamento progressivo
    - Determinação de relevância e recuperação dinâmica de contexto
    - Manipulação de contexto multimodal e considerações de segurança
  - **Abordagens de Implementação**: Arquiteturas de thread único vs. multi-agente
    - Técnicas de fragmentação e priorização de contexto
    - Carregamento progressivo de contexto e estratégias de compressão
    - Abordagens de contexto em camadas e otimização de recuperação
  - **Framework de Medição**: Métricas emergentes para avaliação da eficácia do contexto
    - Eficiência de entrada, desempenho, qualidade e considerações de experiência do utilizador
    - Abordagens experimentais para otimização de contexto
    - Análise de falhas e metodologias de melhoria

#### Atualizações de Navegação do Currículo (README.md)
- **Estrutura Melhorada do Módulo**: Atualização da tabela do currículo para incluir novos tópicos avançados
  - Adição de Engenharia de Contexto (5.14) e Transportes Personalizados (5.15)
  - Formatação consistente e links de navegação em todos os módulos
  - Descrições atualizadas para refletir o escopo atual do conteúdo

### Melhorias na Estrutura de Diretórios
- **Padronização de Nomes**: Renomeação de "mcp transport" para "mcp-transport" para consistência com outras pastas de tópicos avançados
- **Organização de Conteúdo**: Todas as pastas 05-AdvancedTopics agora seguem um padrão de nomenclatura consistente (mcp-[tópico])

### Melhorias na Qualidade da Documentação
- **Alinhamento com a Especificação MCP**: Todo o novo conteúdo faz referência à Especificação MCP atual 2025-06-18
- **Exemplos Multi-Linguagem**: Exemplos de código abrangentes em C#, TypeScript e Python
- **Foco Empresarial**: Padrões prontos para produção e integração com a cloud Azure em todo o conteúdo
- **Documentação Visual**: Diagramas Mermaid para visualização de arquitetura e fluxos

## 18 de agosto de 2025

### Atualização Abrangente da Documentação - Padrões MCP 2025-06-18

#### Melhores Práticas de Segurança MCP (02-Security/) - Modernização Completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescrita completa alinhada com a Especificação MCP 2025-06-18
  - **Requisitos Obrigatórios**: Adição de requisitos explícitos MUST/MUST NOT da especificação oficial com indicadores visuais claros
  - **12 Práticas Fundamentais de Segurança**: Reestruturadas de uma lista de 15 itens para domínios de segurança abrangentes
    - Segurança de Tokens e Autenticação com integração de fornecedores de identidade externos
    - Gestão de Sessões e Segurança de Transporte com requisitos criptográficos
    - Proteção contra Ameaças Específicas de IA com integração Microsoft Prompt Shields
    - Controlo de Acesso e Permissões com princípio de privilégio mínimo
    - Segurança de Conteúdo e Monitorização com integração Azure Content Safety
    - Segurança da Cadeia de Suprimentos com verificação abrangente de componentes
    - Segurança OAuth e Prevenção de Ataques Confused Deputy com implementação PKCE
    - Resposta a Incidentes e Recuperação com capacidades automatizadas
    - Conformidade e Governança com alinhamento regulatório
    - Controles Avançados de Segurança com arquitetura de confiança zero
    - Integração com o Ecossistema de Segurança Microsoft com soluções abrangentes
    - Evolução Contínua de Segurança com práticas adaptativas
  - **Soluções de Segurança Microsoft**: Orientação de integração melhorada para Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Recursos de Implementação**: Links de recursos abrangentes categorizados por Documentação Oficial MCP, Soluções de Segurança Microsoft, Padrões de Segurança e Guias de Implementação

#### Controles Avançados de Segurança (02-Security/) - Implementação Empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisão completa com framework de segurança empresarial
  - **9 Domínios Abrangentes de Segurança**: Expandidos de controles básicos para um framework empresarial detalhado
    - Autenticação e Autorização Avançadas com integração Microsoft Entra ID
    - Segurança de Tokens e Controles Anti-Passthrough com validação abrangente
    - Controles de Segurança de Sessão com prevenção de sequestro
    - Controles de Segurança Específicos de IA com prevenção de injeção de prompts e envenenamento de ferramentas
    - Prevenção de Ataques Confused Deputy com segurança de proxy OAuth
    - Segurança de Execução de Ferramentas com sandboxing e isolamento
    - Controles de Segurança da Cadeia de Suprimentos com verificação de dependências
    - Controles de Monitorização e Deteção com integração SIEM
    - Resposta a Incidentes e Recuperação com capacidades automatizadas
  - **Exemplos de Implementação**: Adição de blocos de configuração YAML detalhados e exemplos de código
  - **Integração com Soluções Microsoft**: Cobertura abrangente de serviços de segurança Azure, GitHub Advanced Security e gestão de identidade empresarial

#### Tópicos Avançados de Segurança (05-AdvancedTopics/mcp-security/) - Implementação Pronta para Produção
- **README.md**: Reescrita completa para implementação de segurança empresarial
  - **Alinhamento com a Especificação Atual**: Atualizado para a Especificação MCP 2025-06-18 com requisitos obrigatórios de segurança
  - **Autenticação Melhorada**: Integração Microsoft Entra ID com exemplos abrangentes em .NET e Java Spring Security
  - **Integração de Segurança de IA**: Implementação Microsoft Prompt Shields e Azure Content Safety com exemplos detalhados em Python
  - **Mitigação Avançada de Ameaças**: Exemplos abrangentes de implementação para
    - Prevenção de Ataques Confused Deputy com PKCE e validação de consentimento do utilizador
    - Prevenção de Passagem de Tokens com validação de audiência e gestão segura de tokens
    - Prevenção de Sequestro de Sessões com vinculação criptográfica e análise comportamental
  - **Integração de Segurança Empresarial**: Monitorização do Azure Application Insights, pipelines de deteção de ameaças e segurança da cadeia de suprimentos
  - **Lista de Verificação de Implementação**: Controles de segurança obrigatórios vs. recomendados com benefícios do ecossistema de segurança Microsoft

### Melhorias na Qualidade e Alinhamento com Padrões
- **Referências à Especificação**: Atualização de todas as referências para a Especificação MCP atual 2025-06-18
- **Ecossistema de Segurança Microsoft**: Orientação de integração melhorada em toda a documentação de segurança
- **Implementação Prática**: Adição de exemplos de código detalhados em .NET, Java e Python com padrões empresariais
- **Organização de Recursos**: Categorização abrangente de documentação oficial, padrões de segurança e guias de implementação
- **Indicadores Visuais**: Marcação clara de requisitos obrigatórios vs. práticas recomendadas

#### Conceitos Fundamentais (01-CoreConcepts/) - Modernização Completa
- **Atualização da Versão do Protocolo**: Atualização para referência à Especificação MCP atual 2025-06-18 com versionamento baseado em data (formato YYYY-MM-DD)
- **Refinamento da Arquitetura**: Descrições melhoradas de Hosts, Clientes e Servidores para refletir padrões atuais de arquitetura MCP
  - Hosts agora claramente definidos como aplicações de IA que coordenam múltiplas conexões de clientes MCP
  - Clientes descritos como conectores de protocolo que mantêm relações um-para-um com servidores
  - Servidores melhorados com cenários de implementação local vs. remota
- **Reestruturação de Primitivas**: Revisão completa das primitivas de servidor e cliente
  - Primitivas de Servidor: Recursos (fontes de dados), Prompts (modelos), Ferramentas (funções executáveis) com explicações detalhadas e exemplos
  - Primitivas de Cliente: Amostragem (completions de LLM), Elicitação (entrada do utilizador), Registo (debugging/monitorização)
  - Atualizado com padrões atuais de descoberta (`*/list`), recuperação (`*/get`) e execução (`*/call`)
- **Arquitetura do Protocolo**: Introdução de modelo de arquitetura de duas camadas
  - Camada de Dados: Fundação JSON-RPC 2.0 com gestão de ciclo de vida e primitivas
  - Camada de Transporte: STDIO (local) e HTTP Streamable com SSE (remoto)
- **Framework de Segurança**: Princípios de segurança abrangentes incluindo consentimento explícito do utilizador, proteção de privacidade de dados, segurança de execução de ferramentas e segurança da camada de transporte
- **Padrões de Comunicação**: Atualização de mensagens do protocolo para mostrar fluxos de inicialização, descoberta, execução e notificação
- **Exemplos de Código**: Exemplos multi-linguagem atualizados (.NET, Java, Python, JavaScript) para refletir padrões atuais do SDK MCP

#### Segurança (02-Security/) - Revisão Abrangente de Segurança  
- **Alinhamento com Padrões**: Alinhamento completo com os requisitos de segurança da Especificação MCP 2025-06-18
- **Evolução da Autenticação**: Documentação da evolução de servidores OAuth personalizados para delegação de fornecedores de identidade externos (Microsoft Entra ID)
- **Análise de Ameaças Específicas de IA**: Cobertura melhorada de vetores de ataque modernos de IA
  - Cenários detalhados de ataques de injeção de prompts com exemplos reais
  - Mecanismos de envenenamento de ferramentas e padrões de ataque "rug pull"
  - Envenenamento de janela de contexto e ataques de confusão de modelos
- **Soluções de Segurança de IA Microsoft**: Cobertura abrangente do ecossistema de segurança Microsoft
  - Prompt Shields de IA com deteção avançada, spotlighting e técnicas de delimitadores
  - Padrões de integração Azure Content Safety
  - GitHub Advanced Security para proteção da cadeia de suprimentos
- **Mitigação Avançada de Ameaças**: Controles de segurança detalhados para
  - Sequestro de sessões com cenários de ataque específicos do MCP e requisitos de ID de sessão criptográfica
  - Problemas de Confused Deputy em cenários de proxy MCP com requisitos explícitos de consentimento
  - Vulnerabilidades de passagem de tokens com controles obrigatórios de validação
- **Segurança da Cadeia de Suprimentos**: Cobertura expandida da cadeia de suprimentos de IA incluindo modelos base, serviços de embeddings, fornecedores de contexto e APIs de terceiros
- **Segurança Fundamental**: Integração melhorada com padrões de segurança empresarial incluindo arquitetura de confiança zero e ecossistema de segurança Microsoft
- **Organização de Recursos**: Links de recursos abrangentes categorizados por tipo (Documentação Oficial, Padrões, Pesquisa, Soluções Microsoft, Guias de Implementação)

### Melhorias na Qualidade da Documentação
- **Objetivos de Aprendizagem Estruturados**: Objetivos de aprendizagem melhorados com resultados específicos e acionáveis 
- **Referências Cruzadas**: Adição de links entre tópicos relacionados de segurança e conceitos fundamentais
- **Informação Atual**: Atualização de todas as referências de data e links de especificação para padrões atuais
- **Orientação de Implementação**: Adição de diretrizes específicas e acionáveis de implementação em todas as seções

## 16 de julho de 2025

### Melhorias no README e Navegação
- Redesenho completo da navegação do currículo no README.md
- Substituí as etiquetas `<details>` por um formato baseado em tabelas mais acessível
- Criei opções de layout alternativas na nova pasta "alternative_layouts"
- Adicionei exemplos de navegação em estilo de cartões, abas e acordeão
- Atualizei a secção de estrutura do repositório para incluir todos os ficheiros mais recentes
- Melhorei a secção "Como Utilizar Este Currículo" com recomendações claras
- Atualizei os links da especificação MCP para apontar para os URLs corretos
- Adicionei a secção de Engenharia de Contexto (5.14) à estrutura do currículo

### Atualizações do Guia de Estudo
- Revisei completamente o guia de estudo para alinhar com a estrutura atual do repositório
- Adicionei novas secções para Clientes e Ferramentas MCP, e Servidores MCP Populares
- Atualizei o Mapa Visual do Currículo para refletir com precisão todos os tópicos
- Melhorei as descrições de Tópicos Avançados para cobrir todas as áreas especializadas
- Atualizei a secção de Estudos de Caso para refletir exemplos reais
- Adicionei este changelog abrangente

### Contribuições da Comunidade (06-CommunityContributions/)
- Adicionei informações detalhadas sobre servidores MCP para geração de imagens
- Adicionei uma secção abrangente sobre como usar Claude no VSCode
- Adicionei instruções de configuração e uso do cliente terminal Cline
- Atualizei a secção de clientes MCP para incluir todas as opções populares
- Melhorei os exemplos de contribuição com amostras de código mais precisas

### Tópicos Avançados (05-AdvancedTopics/)
- Organizei todas as pastas de tópicos especializados com nomes consistentes
- Adicionei materiais e exemplos de engenharia de contexto
- Adicionei documentação de integração do agente Foundry
- Melhorei a documentação de integração de segurança do Entra ID

## 11 de junho de 2025

### Criação Inicial
- Lançada a primeira versão do currículo MCP para Iniciantes
- Criada a estrutura básica para todas as 10 secções principais
- Implementado o Mapa Visual do Currículo para navegação
- Adicionados projetos de exemplo iniciais em várias linguagens de programação

### Primeiros Passos (03-GettingStarted/)
- Criados os primeiros exemplos de implementação de servidor
- Adicionadas orientações para desenvolvimento de clientes
- Incluídas instruções de integração de clientes LLM
- Adicionada documentação de integração com VS Code
- Implementados exemplos de servidor com Server-Sent Events (SSE)

### Conceitos Fundamentais (01-CoreConcepts/)
- Adicionada explicação detalhada sobre arquitetura cliente-servidor
- Criada documentação sobre componentes chave do protocolo
- Documentados padrões de mensagens no MCP

## 23 de maio de 2025

### Estrutura do Repositório
- Inicializado o repositório com estrutura básica de pastas
- Criados ficheiros README para cada secção principal
- Configurada infraestrutura de tradução
- Adicionados recursos de imagem e diagramas

### Documentação
- Criado README.md inicial com visão geral do currículo
- Adicionados CODE_OF_CONDUCT.md e SECURITY.md
- Configurado SUPPORT.md com orientações para obter ajuda
- Criada estrutura preliminar do guia de estudo

## 15 de abril de 2025

### Planeamento e Estrutura
- Planeamento inicial para o currículo MCP para Iniciantes
- Definidos objetivos de aprendizagem e público-alvo
- Estruturadas as 10 secções do currículo
- Desenvolvida a estrutura conceptual para exemplos e estudos de caso
- Criados protótipos iniciais de exemplos para conceitos chave

---

