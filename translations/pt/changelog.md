<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T13:19:29+00:00",
  "source_file": "changelog.md",
  "language_code": "pt"
}
-->
# Registo de Alterações: Currículo MCP para Iniciantes

Este documento serve como registo de todas as alterações significativas feitas ao currículo do Model Context Protocol (MCP) para Iniciantes. As alterações estão documentadas em ordem cronológica inversa (alterações mais recentes primeiro).

## 29 de setembro de 2025

### Laboratórios de Integração de Base de Dados do Servidor MCP - Percurso Prático Abrangente

#### 11-MCPServerHandsOnLabs - Novo Currículo Completo de Integração de Base de Dados
- **Percurso de Aprendizagem com 13 Laboratórios**: Adicionado currículo prático abrangente para construir servidores MCP prontos para produção com integração de base de dados PostgreSQL
  - **Implementação Realista**: Caso de uso de análise de retalho Zava demonstrando padrões empresariais
  - **Progressão Estruturada de Aprendizagem**:
    - **Laboratórios 00-03: Fundamentos** - Introdução, Arquitetura Base, Segurança e Multi-Tenancy, Configuração do Ambiente
    - **Laboratórios 04-06: Construção do Servidor MCP** - Design e Esquema da Base de Dados, Implementação do Servidor MCP, Desenvolvimento de Ferramentas  
    - **Laboratórios 07-09: Funcionalidades Avançadas** - Integração de Pesquisa Semântica, Testes e Depuração, Integração com VS Code
    - **Laboratórios 10-12: Produção e Melhores Práticas** - Estratégias de Implementação, Monitorização e Observabilidade, Melhores Práticas e Otimização
  - **Tecnologias Empresariais**: Framework FastMCP, PostgreSQL com pgvector, embeddings Azure OpenAI, Azure Container Apps, Application Insights
  - **Funcionalidades Avançadas**: Segurança a Nível de Linha (RLS), pesquisa semântica, acesso a dados multi-tenant, embeddings vetoriais, monitorização em tempo real

#### Padronização de Terminologia - Conversão de Módulo para Laboratório
- **Atualização Abrangente da Documentação**: Atualizados sistematicamente todos os ficheiros README em 11-MCPServerHandsOnLabs para usar a terminologia "Laboratório" em vez de "Módulo"
  - **Cabeçalhos de Secção**: Alterado "O que este módulo cobre" para "O que este laboratório cobre" em todos os 13 laboratórios
  - **Descrição de Conteúdo**: Alterado "Este módulo fornece..." para "Este laboratório fornece..." em toda a documentação
  - **Objetivos de Aprendizagem**: Atualizado "No final deste módulo..." para "No final deste laboratório..."
  - **Links de Navegação**: Convertidas todas as referências "Módulo XX:" para "Laboratório XX:" em referências cruzadas e navegação
  - **Rastreio de Conclusão**: Atualizado "Após completar este módulo..." para "Após completar este laboratório..."
  - **Referências Técnicas Preservadas**: Mantidas referências a módulos Python em ficheiros de configuração (ex.: `"module": "mcp_server.main"`)

#### Melhoria do Guia de Estudo (study_guide.md)
- **Mapa Visual do Currículo**: Adicionada nova secção "11. Laboratórios de Integração de Base de Dados" com visualização detalhada da estrutura dos laboratórios
- **Estrutura do Repositório**: Atualizado de dez para onze secções principais com descrição detalhada de 11-MCPServerHandsOnLabs
- **Orientação para o Percurso de Aprendizagem**: Instruções de navegação melhoradas para cobrir as secções 00-11
- **Cobertura Tecnológica**: Adicionados detalhes sobre integração de FastMCP, PostgreSQL e serviços Azure
- **Resultados de Aprendizagem**: Enfatizado o desenvolvimento de servidores prontos para produção, padrões de integração de base de dados e segurança empresarial

#### Melhoria da Estrutura do README Principal
- **Terminologia Baseada em Laboratórios**: Atualizado README.md principal em 11-MCPServerHandsOnLabs para usar consistentemente a estrutura "Laboratório"
- **Organização do Percurso de Aprendizagem**: Progressão clara desde conceitos fundamentais até implementação avançada e implementação em produção
- **Foco Realista**: Ênfase na aprendizagem prática com padrões e tecnologias empresariais

### Melhorias na Qualidade e Consistência da Documentação
- **Ênfase na Aprendizagem Prática**: Reforçado o enfoque prático baseado em laboratórios em toda a documentação
- **Foco em Padrões Empresariais**: Destacadas implementações prontas para produção e considerações de segurança empresarial
- **Integração Tecnológica**: Cobertura abrangente de serviços modernos Azure e padrões de integração de IA
- **Progressão de Aprendizagem**: Caminho claro e estruturado desde conceitos básicos até implementação em produção

## 26 de setembro de 2025

### Melhoria de Estudos de Caso - Integração do Registo MCP no GitHub

#### Estudos de Caso (09-CaseStudy/) - Foco no Desenvolvimento do Ecossistema
- **README.md**: Expansão significativa com estudo de caso abrangente sobre o Registo MCP no GitHub
  - **Estudo de Caso do Registo MCP no GitHub**: Novo estudo de caso abrangente examinando o lançamento do Registo MCP no GitHub em setembro de 2025
    - **Análise do Problema**: Exame detalhado dos desafios fragmentados de descoberta e implementação de servidores MCP
    - **Arquitetura da Solução**: Abordagem centralizada do registo do GitHub com instalação de um clique no VS Code
    - **Impacto Empresarial**: Melhorias mensuráveis na integração e produtividade de desenvolvedores
    - **Valor Estratégico**: Foco na implementação modular de agentes e interoperabilidade entre ferramentas
    - **Desenvolvimento do Ecossistema**: Posicionamento como plataforma fundamental para integração de agentes
  - **Estrutura Melhorada de Estudos de Caso**: Atualizados todos os sete estudos de caso com formatação consistente e descrições abrangentes
    - Agentes de Viagem Azure AI: Ênfase na orquestração multi-agente
    - Integração Azure DevOps: Foco na automação de fluxos de trabalho
    - Recuperação de Documentação em Tempo Real: Implementação de cliente Python no console
    - Gerador Interativo de Planos de Estudo: Aplicação web conversacional Chainlit
    - Documentação no Editor: Integração com VS Code e GitHub Copilot
    - Gestão de API Azure: Padrões de integração de API empresarial
    - Registo MCP no GitHub: Desenvolvimento do ecossistema e plataforma comunitária
  - **Conclusão Abrangente**: Secção de conclusão reescrita destacando sete estudos de caso abrangendo múltiplas dimensões de implementação MCP
    - Integração Empresarial, Orquestração Multi-Agente, Produtividade de Desenvolvedores
    - Desenvolvimento do Ecossistema, Aplicações Educacionais categorizadas
    - Insights melhorados sobre padrões arquiteturais, estratégias de implementação e melhores práticas
    - Ênfase no MCP como protocolo maduro e pronto para produção

#### Atualizações do Guia de Estudo (study_guide.md)
- **Mapa Visual do Currículo**: Atualizado o mapa mental para incluir o Registo MCP no GitHub na secção de Estudos de Caso
- **Descrição dos Estudos de Caso**: Melhorada de descrições genéricas para detalhamento dos sete estudos de caso abrangentes
- **Estrutura do Repositório**: Atualizada a secção 10 para refletir cobertura abrangente de estudos de caso com detalhes específicos de implementação
- **Integração do Registo de Alterações**: Adicionada entrada de 26 de setembro de 2025 documentando a adição do Registo MCP no GitHub e melhorias nos estudos de caso
- **Atualizações de Data**: Atualizado o carimbo de data no rodapé para refletir a revisão mais recente (26 de setembro de 2025)

### Melhorias na Qualidade da Documentação
- **Melhoria de Consistência**: Formatação e estrutura padronizadas nos sete exemplos de estudos de caso
- **Cobertura Abrangente**: Estudos de caso agora abrangem cenários empresariais, produtividade de desenvolvedores e desenvolvimento do ecossistema
- **Posicionamento Estratégico**: Foco melhorado no MCP como plataforma fundamental para implementação de sistemas de agentes
- **Integração de Recursos**: Atualizados recursos adicionais para incluir link do Registo MCP no GitHub

## 15 de setembro de 2025

### Expansão de Tópicos Avançados - Transportes Personalizados e Engenharia de Contexto

#### Transportes Personalizados MCP (05-AdvancedTopics/mcp-transport/) - Novo Guia de Implementação Avançada
- **README.md**: Guia completo de implementação para mecanismos de transporte personalizados MCP
  - **Transporte Azure Event Grid**: Implementação abrangente de transporte sem servidor orientado por eventos
    - Exemplos em C#, TypeScript e Python com integração Azure Functions
    - Padrões de arquitetura orientada por eventos para soluções MCP escaláveis
    - Receptores de webhook e manipulação de mensagens baseada em push
  - **Transporte Azure Event Hubs**: Implementação de transporte de streaming de alta capacidade
    - Capacidades de streaming em tempo real para cenários de baixa latência
    - Estratégias de particionamento e gestão de checkpoints
    - Agrupamento de mensagens e otimização de desempenho
  - **Padrões de Integração Empresarial**: Exemplos arquiteturais prontos para produção
    - Processamento MCP distribuído em múltiplas Azure Functions
    - Arquiteturas híbridas de transporte combinando múltiplos tipos de transporte
    - Durabilidade de mensagens, confiabilidade e estratégias de tratamento de erros
  - **Segurança e Monitorização**: Integração com Azure Key Vault e padrões de observabilidade
    - Autenticação com identidade gerida e acesso com privilégios mínimos
    - Telemetria Application Insights e monitorização de desempenho
    - Circuit breakers e padrões de tolerância a falhas
  - **Frameworks de Teste**: Estratégias abrangentes de teste para transportes personalizados
    - Testes unitários com doubles de teste e frameworks de mocking
    - Testes de integração com Azure Test Containers
    - Considerações sobre testes de desempenho e carga

#### Engenharia de Contexto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina Emergente de IA
- **README.md**: Exploração abrangente da engenharia de contexto como campo emergente
  - **Princípios Fundamentais**: Partilha completa de contexto, consciência de decisão de ação e gestão de janela de contexto
  - **Alinhamento com o Protocolo MCP**: Como o design MCP aborda os desafios da engenharia de contexto
    - Limitações de janela de contexto e estratégias de carregamento progressivo
    - Determinação de relevância e recuperação dinâmica de contexto
    - Manipulação de contexto multimodal e considerações de segurança
  - **Abordagens de Implementação**: Arquiteturas single-threaded vs. multi-agente
    - Técnicas de fragmentação e priorização de contexto
    - Carregamento progressivo de contexto e estratégias de compressão
    - Abordagens de contexto em camadas e otimização de recuperação
  - **Framework de Medição**: Métricas emergentes para avaliação da eficácia do contexto
    - Eficiência de entrada, desempenho, qualidade e considerações de experiência do utilizador
    - Abordagens experimentais para otimização de contexto
    - Análise de falhas e metodologias de melhoria

#### Atualizações de Navegação do Currículo (README.md)
- **Estrutura Melhorada de Módulos**: Atualizada tabela do currículo para incluir novos tópicos avançados
  - Adicionados Engenharia de Contexto (5.14) e Transporte Personalizado (5.15)
  - Formatação consistente e links de navegação em todos os módulos
  - Descrições atualizadas para refletir o escopo atual do conteúdo

### Melhorias na Estrutura de Diretórios
- **Padronização de Nomes**: Renomeado "mcp transport" para "mcp-transport" para consistência com outras pastas de tópicos avançados
- **Organização de Conteúdo**: Todas as pastas 05-AdvancedTopics agora seguem padrão de nomenclatura consistente (mcp-[tópico])

### Melhorias na Qualidade da Documentação
- **Alinhamento com a Especificação MCP**: Todo o novo conteúdo referencia a Especificação MCP atual 2025-06-18
- **Exemplos Multi-Linguagem**: Exemplos de código abrangentes em C#, TypeScript e Python
- **Foco Empresarial**: Padrões prontos para produção e integração com a cloud Azure em todo o conteúdo
- **Documentação Visual**: Diagramas Mermaid para visualização de arquitetura e fluxos

## 18 de agosto de 2025

### Atualização Abrangente da Documentação - Normas MCP 2025-06-18

#### Melhores Práticas de Segurança MCP (02-Security/) - Modernização Completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescrita completa alinhada com a Especificação MCP 2025-06-18
  - **Requisitos Obrigatórios**: Adicionados requisitos explícitos MUST/MUST NOT da especificação oficial com indicadores visuais claros
  - **12 Práticas Fundamentais de Segurança**: Reestruturado de lista de 15 itens para domínios abrangentes de segurança
    - Segurança de Tokens e Autenticação com integração de fornecedor de identidade externo
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
  - **Recursos de Implementação**: Links de recursos abrangentes categorizados por Documentação Oficial MCP, Soluções de Segurança Microsoft, Normas de Segurança e Guias de Implementação

#### Controles Avançados de Segurança (02-Security/) - Implementação Empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisão completa com framework de segurança empresarial
  - **9 Domínios Abrangentes de Segurança**: Expandido de controles básicos para framework empresarial detalhado
    - Autenticação e Autorização Avançadas com integração Microsoft Entra ID
    - Segurança de Tokens e Controles Anti-Passthrough com validação abrangente
    - Controles de Segurança de Sessão com prevenção de sequestro
    - Controles de Segurança Específicos de IA com prevenção de injeção de prompts e envenenamento de ferramentas
    - Prevenção de Ataques Confused Deputy com segurança de proxy OAuth
    - Segurança na Execução de Ferramentas com sandboxing e isolamento
    - Controles de Segurança da Cadeia de Suprimentos com verificação de dependências
    - Controles de Monitorização e Deteção com integração SIEM
    - Resposta a Incidentes e Recuperação com capacidades automatizadas
  - **Exemplos de Implementação**: Adicionados blocos de configuração YAML detalhados e exemplos de código
  - **Integração com Soluções Microsoft**: Cobertura abrangente de serviços de segurança Azure, GitHub Advanced Security e gestão de identidade empresarial

#### Segurança em Tópicos Avançados (05-AdvancedTopics/mcp-security/) - Implementação Pronta para Produção
- **README.md**: Reescrita completa para implementação de segurança empresarial
  - **Alinhamento com a Especificação Atual**: Atualizado para a Especificação MCP 2025-06-18 com requisitos obrigatórios de segurança
  - **Autenticação Melhorada**: Integração Microsoft Entra ID com exemplos abrangentes em .NET e Java Spring Security
  - **Integração de Segurança de IA**: Implementação Microsoft Prompt Shields e Azure Content Safety com exemplos detalhados em Python
  - **Mitigação Avançada de Ameaças**: Exemplos abrangentes de implementação para
    - Prevenção de Ataques Confused Deputy com PKCE e validação de consentimento do utilizador
    - Prevenção de Passagem de Tokens com validação de audiência e gestão segura de tokens
    - Prevenção de Sequestro de Sessão com vinculação criptográfica e análise comportamental
  - **Integração de Segurança Empresarial**: Monitorização Azure Application Insights, pipelines de deteção de ameaças e segurança da cadeia de suprimentos
  - **Lista de Verificação de Implementação**: Controles de segurança obrigatórios vs. recomendados claros com benefícios do ecossistema de segurança Microsoft

### Qualidade da Documentação e Alinhamento com Normas
- **Referências à Especificação**: Atualizadas todas as referências para a Especificação MCP atual 2025-06-18
- **Ecossistema de Segurança Microsoft**: Orientação de integração melhorada em toda a documentação de segurança
- **Implementação Prática**: Adicionados exemplos detalhados de código em .NET, Java e Python com padrões empresariais
- **Organização de Recursos**: Categorização abrangente de documentação oficial, normas de segurança e guias de implementação
- **Indicadores Visuais**: Marcação clara dos requisitos obrigatórios vs. práticas recomendadas

#### Conceitos Fundamentais (01-CoreConcepts/) - Modernização Completa
- **Atualização da Versão do Protocolo**: Atualizado para referenciar a Especificação MCP atual de 2025-06-18 com versionamento baseado em datas (formato YYYY-MM-DD)
- **Aperfeiçoamento da Arquitetura**: Descrições aprimoradas de Hosts, Clientes e Servidores para refletir os padrões atuais da arquitetura MCP
  - Hosts agora definidos claramente como aplicações de IA que coordenam múltiplas conexões de clientes MCP
  - Clientes descritos como conectores de protocolo que mantêm relações de um para um com servidores
  - Servidores aprimorados com cenários de implementação local vs. remota
- **Reestruturação de Primitivas**: Revisão completa das primitivas de servidor e cliente
  - Primitivas de Servidor: Recursos (fontes de dados), Prompts (modelos), Ferramentas (funções executáveis) com explicações detalhadas e exemplos
  - Primitivas de Cliente: Amostragem (completamentos de LLM), Elicitação (entrada do utilizador), Registo (depuração/monitorização)
  - Atualizado com padrões atuais de descoberta (`*/list`), recuperação (`*/get`) e execução (`*/call`)
- **Arquitetura do Protocolo**: Introdução de um modelo de arquitetura de duas camadas
  - Camada de Dados: Base JSON-RPC 2.0 com gestão de ciclo de vida e primitivas
  - Camada de Transporte: STDIO (local) e HTTP com SSE (remoto) como mecanismos de transporte
- **Estrutura de Segurança**: Princípios abrangentes de segurança, incluindo consentimento explícito do utilizador, proteção de privacidade de dados, segurança na execução de ferramentas e segurança na camada de transporte
- **Padrões de Comunicação**: Mensagens do protocolo atualizadas para mostrar fluxos de inicialização, descoberta, execução e notificação
- **Exemplos de Código**: Exemplos multi-linguagem atualizados (.NET, Java, Python, JavaScript) para refletir os padrões atuais do SDK MCP

#### Segurança (02-Security/) - Revisão Abrangente de Segurança  
- **Alinhamento com Normas**: Alinhamento completo com os requisitos de segurança da Especificação MCP 2025-06-18
- **Evolução da Autenticação**: Documentada a evolução de servidores OAuth personalizados para delegação de provedores de identidade externos (Microsoft Entra ID)
- **Análise de Ameaças Específicas de IA**: Cobertura aprimorada de vetores de ataque modernos de IA
  - Cenários detalhados de ataques de injeção de prompts com exemplos reais
  - Mecanismos de envenenamento de ferramentas e padrões de ataque "rug pull"
  - Envenenamento da janela de contexto e ataques de confusão de modelos
- **Soluções de Segurança da Microsoft para IA**: Cobertura abrangente do ecossistema de segurança da Microsoft
  - Escudos de Prompt de IA com técnicas avançadas de deteção, destaque e delimitadores
  - Padrões de integração com Azure Content Safety
  - GitHub Advanced Security para proteção da cadeia de fornecimento
- **Mitigação Avançada de Ameaças**: Controles de segurança detalhados para
  - Sequestro de sessão com cenários de ataque específicos do MCP e requisitos criptográficos de ID de sessão
  - Problemas de "deputado confuso" em cenários de proxy MCP com requisitos de consentimento explícito
  - Vulnerabilidades de passagem de token com controles obrigatórios de validação
- **Segurança da Cadeia de Fornecimento**: Cobertura expandida da cadeia de fornecimento de IA, incluindo modelos fundacionais, serviços de embeddings, fornecedores de contexto e APIs de terceiros
- **Segurança Fundamental**: Integração aprimorada com padrões de segurança empresarial, incluindo arquitetura de confiança zero e ecossistema de segurança da Microsoft
- **Organização de Recursos**: Links de recursos abrangentes categorizados por tipo (Documentação Oficial, Normas, Pesquisa, Soluções da Microsoft, Guias de Implementação)

### Melhorias na Qualidade da Documentação
- **Objetivos de Aprendizagem Estruturados**: Objetivos de aprendizagem aprimorados com resultados específicos e acionáveis
- **Referências Cruzadas**: Adicionados links entre tópicos relacionados de segurança e conceitos fundamentais
- **Informação Atual**: Atualizadas todas as referências de datas e links de especificações para normas atuais
- **Orientação de Implementação**: Adicionadas diretrizes específicas e acionáveis de implementação em ambas as secções

## 16 de julho de 2025

### Melhorias no README e Navegação
- Redesenho completo da navegação do currículo no README.md
- Substituídos os `<details>` por um formato baseado em tabelas mais acessível
- Criadas opções de layout alternativas na nova pasta "alternative_layouts"
- Adicionados exemplos de navegação em estilo de cartões, abas e acordeão
- Atualizada a secção de estrutura do repositório para incluir todos os ficheiros mais recentes
- Melhorada a secção "Como Usar Este Currículo" com recomendações claras
- Atualizados os links de especificação MCP para apontar para os URLs corretos
- Adicionada a secção de Engenharia de Contexto (5.14) à estrutura do currículo

### Atualizações do Guia de Estudo
- Revisão completa do guia de estudo para alinhar com a estrutura atual do repositório
- Adicionadas novas secções para Clientes e Ferramentas MCP, e Servidores MCP Populares
- Atualizado o Mapa Visual do Currículo para refletir com precisão todos os tópicos
- Melhoradas as descrições de Tópicos Avançados para cobrir todas as áreas especializadas
- Atualizada a secção de Estudos de Caso para refletir exemplos reais
- Adicionado este changelog abrangente

### Contribuições da Comunidade (06-CommunityContributions/)
- Adicionada informação detalhada sobre servidores MCP para geração de imagens
- Adicionada secção abrangente sobre o uso do Claude no VSCode
- Adicionadas instruções de configuração e uso do cliente terminal Cline
- Atualizada a secção de clientes MCP para incluir todas as opções populares de clientes
- Melhorados os exemplos de contribuição com amostras de código mais precisas

### Tópicos Avançados (05-AdvancedTopics/)
- Organizadas todas as pastas de tópicos especializados com nomes consistentes
- Adicionados materiais e exemplos de engenharia de contexto
- Adicionada documentação de integração de agentes Foundry
- Melhorada a documentação de integração de segurança do Entra ID

## 11 de junho de 2025

### Criação Inicial
- Lançada a primeira versão do currículo MCP para Iniciantes
- Criada estrutura básica para todas as 10 secções principais
- Implementado Mapa Visual do Currículo para navegação
- Adicionados projetos de exemplo iniciais em várias linguagens de programação

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
- Criados ficheiros README para cada secção principal
- Configurada infraestrutura de tradução
- Adicionados ativos de imagem e diagramas

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
- Desenvolvido quadro conceptual para exemplos e estudos de caso
- Criados protótipos iniciais de exemplos para conceitos-chave

---

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se uma tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas resultantes do uso desta tradução.