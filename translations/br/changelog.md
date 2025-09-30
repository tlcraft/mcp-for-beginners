<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T16:14:52+00:00",
  "source_file": "changelog.md",
  "language_code": "br"
}
-->
# Registro de Alterações: Currículo MCP para Iniciantes

Este documento serve como registro de todas as mudanças significativas feitas no currículo do Protocolo de Contexto de Modelo (MCP) para Iniciantes. As alterações estão documentadas em ordem cronológica inversa (alterações mais recentes primeiro).

## 29 de setembro de 2025

### Laboratórios de Integração de Banco de Dados do Servidor MCP - Caminho de Aprendizado Prático Abrangente

#### 11-MCPServerHandsOnLabs - Novo Currículo Completo de Integração de Banco de Dados
- **Caminho de Aprendizado com 13 Laboratórios**: Adicionado currículo prático abrangente para construir servidores MCP prontos para produção com integração ao banco de dados PostgreSQL
  - **Implementação Real**: Caso de uso de análise de varejo da Zava demonstrando padrões de nível empresarial
  - **Progressão Estruturada de Aprendizado**:
    - **Laboratórios 00-03: Fundamentos** - Introdução, Arquitetura Principal, Segurança e Multi-Tenancy, Configuração do Ambiente
    - **Laboratórios 04-06: Construindo o Servidor MCP** - Design e Esquema do Banco de Dados, Implementação do Servidor MCP, Desenvolvimento de Ferramentas  
    - **Laboratórios 07-09: Recursos Avançados** - Integração de Busca Semântica, Testes e Depuração, Integração com VS Code
    - **Laboratórios 10-12: Produção e Melhores Práticas** - Estratégias de Implantação, Monitoramento e Observabilidade, Melhores Práticas e Otimização
  - **Tecnologias Empresariais**: Framework FastMCP, PostgreSQL com pgvector, embeddings do Azure OpenAI, Azure Container Apps, Application Insights
  - **Recursos Avançados**: Segurança em Nível de Linha (RLS), busca semântica, acesso a dados multi-tenant, embeddings vetoriais, monitoramento em tempo real

#### Padronização de Terminologia - Conversão de Módulo para Laboratório
- **Atualização Abrangente da Documentação**: Atualizados sistematicamente todos os arquivos README em 11-MCPServerHandsOnLabs para usar a terminologia "Laboratório" em vez de "Módulo"
  - **Cabeçalhos de Seção**: Alterado "O que este módulo cobre" para "O que este laboratório cobre" em todos os 13 laboratórios
  - **Descrição de Conteúdo**: Alterado "Este módulo fornece..." para "Este laboratório fornece..." em toda a documentação
  - **Objetivos de Aprendizado**: Atualizado "Ao final deste módulo..." para "Ao final deste laboratório..."
  - **Links de Navegação**: Convertidas todas as referências "Módulo XX:" para "Laboratório XX:" em referências cruzadas e navegação
  - **Rastreamento de Conclusão**: Atualizado "Após concluir este módulo..." para "Após concluir este laboratório..."
  - **Referências Técnicas Preservadas**: Mantidas referências a módulos Python em arquivos de configuração (ex.: `"module": "mcp_server.main"`)

#### Melhoria no Guia de Estudos (study_guide.md)
- **Mapa Visual do Currículo**: Adicionada nova seção "11. Laboratórios de Integração de Banco de Dados" com visualização abrangente da estrutura dos laboratórios
- **Estrutura do Repositório**: Atualizado de dez para onze seções principais com descrição detalhada de 11-MCPServerHandsOnLabs
- **Orientação de Caminho de Aprendizado**: Instruções de navegação aprimoradas para cobrir as seções 00-11
- **Cobertura Tecnológica**: Adicionados detalhes sobre integração com FastMCP, PostgreSQL e serviços do Azure
- **Resultados de Aprendizado**: Ênfase no desenvolvimento de servidores prontos para produção, padrões de integração de banco de dados e segurança empresarial

#### Melhoria na Estrutura do README Principal
- **Terminologia Baseada em Laboratórios**: Atualizado README.md principal em 11-MCPServerHandsOnLabs para usar consistentemente a estrutura de "Laboratório"
- **Organização do Caminho de Aprendizado**: Progressão clara de conceitos fundamentais até implementação avançada e implantação em produção
- **Foco no Mundo Real**: Ênfase no aprendizado prático com padrões e tecnologias de nível empresarial

### Melhorias na Qualidade e Consistência da Documentação
- **Ênfase no Aprendizado Prático**: Reforçado o enfoque prático baseado em laboratórios em toda a documentação
- **Foco em Padrões Empresariais**: Destacadas implementações prontas para produção e considerações de segurança empresarial
- **Integração Tecnológica**: Cobertura abrangente de serviços modernos do Azure e padrões de integração com IA
- **Progressão de Aprendizado**: Caminho claro e estruturado de conceitos básicos até implantação em produção

## 26 de setembro de 2025

### Melhoria nos Estudos de Caso - Integração com o Registro MCP do GitHub

#### Estudos de Caso (09-CaseStudy/) - Foco no Desenvolvimento do Ecossistema
- **README.md**: Expansão significativa com estudo de caso abrangente sobre o Registro MCP do GitHub
  - **Estudo de Caso do Registro MCP do GitHub**: Novo estudo de caso abrangente examinando o lançamento do Registro MCP do GitHub em setembro de 2025
    - **Análise do Problema**: Exame detalhado dos desafios fragmentados de descoberta e implantação de servidores MCP
    - **Arquitetura da Solução**: Abordagem centralizada do registro do GitHub com instalação de um clique no VS Code
    - **Impacto nos Negócios**: Melhorias mensuráveis na integração e produtividade de desenvolvedores
    - **Valor Estratégico**: Foco na implantação modular de agentes e interoperabilidade entre ferramentas
    - **Desenvolvimento do Ecossistema**: Posicionamento como plataforma fundamental para integração de agentes
  - **Estrutura Aprimorada dos Estudos de Caso**: Atualizados todos os sete estudos de caso com formatação consistente e descrições abrangentes
    - Agentes de Viagem com IA do Azure: Ênfase na orquestração multi-agente
    - Integração com Azure DevOps: Foco na automação de fluxos de trabalho
    - Recuperação de Documentação em Tempo Real: Implementação de cliente console em Python
    - Gerador Interativo de Plano de Estudos: Aplicativo web conversacional com Chainlit
    - Documentação no Editor: Integração com VS Code e GitHub Copilot
    - Gerenciamento de API do Azure: Padrões de integração de API empresarial
    - Registro MCP do GitHub: Desenvolvimento do ecossistema e plataforma comunitária
  - **Conclusão Abrangente**: Seção de conclusão reescrita destacando sete estudos de caso abrangendo múltiplas dimensões de implementação do MCP
    - Integração Empresarial, Orquestração Multi-Agente, Produtividade de Desenvolvedores
    - Desenvolvimento do Ecossistema, Aplicações Educacionais categorizadas
    - Insights aprimorados sobre padrões arquitetônicos, estratégias de implementação e melhores práticas
    - Ênfase no MCP como protocolo maduro e pronto para produção

#### Atualizações no Guia de Estudos (study_guide.md)
- **Mapa Visual do Currículo**: Atualizado o mapa mental para incluir o Registro MCP do GitHub na seção de Estudos de Caso
- **Descrição dos Estudos de Caso**: Melhorada de descrições genéricas para detalhamento dos sete estudos de caso abrangentes
- **Estrutura do Repositório**: Atualizada a seção 10 para refletir a cobertura abrangente dos estudos de caso com detalhes específicos de implementação
- **Integração com o Registro de Alterações**: Adicionada entrada de 26 de setembro de 2025 documentando a adição do Registro MCP do GitHub e melhorias nos estudos de caso
- **Atualizações de Data**: Atualizado o carimbo de data no rodapé para refletir a revisão mais recente (26 de setembro de 2025)

### Melhorias na Qualidade da Documentação
- **Aprimoramento de Consistência**: Formatação e estrutura dos estudos de caso padronizadas em todos os sete exemplos
- **Cobertura Abrangente**: Estudos de caso agora abrangem cenários empresariais, produtividade de desenvolvedores e desenvolvimento de ecossistemas
- **Posicionamento Estratégico**: Foco aprimorado no MCP como plataforma fundamental para implantação de sistemas de agentes
- **Integração de Recursos**: Atualizados recursos adicionais para incluir link do Registro MCP do GitHub

## 15 de setembro de 2025

### Expansão de Tópicos Avançados - Transportes Personalizados e Engenharia de Contexto

#### Transportes Personalizados do MCP (05-AdvancedTopics/mcp-transport/) - Novo Guia de Implementação Avançada
- **README.md**: Guia completo de implementação para mecanismos de transporte personalizados do MCP
  - **Transporte com Azure Event Grid**: Implementação abrangente de transporte sem servidor e orientado por eventos
    - Exemplos em C#, TypeScript e Python com integração ao Azure Functions
    - Padrões de arquitetura orientada por eventos para soluções MCP escaláveis
    - Receptores de webhook e manipulação de mensagens baseada em push
  - **Transporte com Azure Event Hubs**: Implementação de transporte de streaming de alta capacidade
    - Capacidades de streaming em tempo real para cenários de baixa latência
    - Estratégias de particionamento e gerenciamento de checkpoints
    - Agrupamento de mensagens e otimização de desempenho
  - **Padrões de Integração Empresarial**: Exemplos arquitetônicos prontos para produção
    - Processamento MCP distribuído em várias funções do Azure
    - Arquiteturas híbridas de transporte combinando múltiplos tipos de transporte
    - Estratégias de durabilidade, confiabilidade e manipulação de erros de mensagens
  - **Segurança e Monitoramento**: Integração com Azure Key Vault e padrões de observabilidade
    - Autenticação com identidade gerenciada e acesso com menor privilégio
    - Telemetria do Application Insights e monitoramento de desempenho
    - Circuit breakers e padrões de tolerância a falhas
  - **Frameworks de Teste**: Estratégias abrangentes de teste para transportes personalizados
    - Testes unitários com doubles de teste e frameworks de mocking
    - Testes de integração com Azure Test Containers
    - Considerações sobre testes de desempenho e carga

#### Engenharia de Contexto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina Emergente de IA
- **README.md**: Exploração abrangente da engenharia de contexto como campo emergente
  - **Princípios Fundamentais**: Compartilhamento completo de contexto, consciência de decisão de ação e gerenciamento de janela de contexto
  - **Alinhamento ao Protocolo MCP**: Como o design do MCP aborda os desafios da engenharia de contexto
    - Limitações de janela de contexto e estratégias de carregamento progressivo
    - Determinação de relevância e recuperação dinâmica de contexto
    - Manipulação de contexto multimodal e considerações de segurança
  - **Abordagens de Implementação**: Arquiteturas de thread único vs. multi-agente
    - Técnicas de fragmentação e priorização de contexto
    - Carregamento progressivo de contexto e estratégias de compressão
    - Abordagens de contexto em camadas e otimização de recuperação
  - **Framework de Medição**: Métricas emergentes para avaliação da eficácia do contexto
    - Eficiência de entrada, desempenho, qualidade e considerações de experiência do usuário
    - Abordagens experimentais para otimização de contexto
    - Análise de falhas e metodologias de melhoria

#### Atualizações de Navegação no Currículo (README.md)
- **Estrutura de Módulos Aprimorada**: Atualizada tabela do currículo para incluir novos tópicos avançados
  - Adicionados Engenharia de Contexto (5.14) e Transporte Personalizado (5.15)
  - Formatação consistente e links de navegação em todos os módulos
  - Descrições atualizadas para refletir o escopo atual do conteúdo

### Melhorias na Estrutura de Diretórios
- **Padronização de Nomes**: Renomeado "mcp transport" para "mcp-transport" para consistência com outras pastas de tópicos avançados
- **Organização de Conteúdo**: Todas as pastas 05-AdvancedTopics agora seguem padrão de nomenclatura consistente (mcp-[tópico])

### Melhorias na Qualidade da Documentação
- **Alinhamento à Especificação MCP**: Todo o novo conteúdo faz referência à Especificação MCP atual 2025-06-18
- **Exemplos Multi-Linguagem**: Exemplos de código abrangentes em C#, TypeScript e Python
- **Foco Empresarial**: Padrões prontos para produção e integração com a nuvem Azure em todo o conteúdo
- **Documentação Visual**: Diagramas Mermaid para visualização de arquitetura e fluxo

## 18 de agosto de 2025

### Atualização Abrangente da Documentação - Padrões MCP 2025-06-18

#### Melhores Práticas de Segurança do MCP (02-Security/) - Modernização Completa
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
    - Integração ao Ecossistema de Segurança da Microsoft com soluções abrangentes
    - Evolução Contínua de Segurança com práticas adaptativas
  - **Soluções de Segurança da Microsoft**: Orientação aprimorada para integração com Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Recursos de Implementação**: Links de recursos abrangentes categorizados por Documentação Oficial do MCP, Soluções de Segurança da Microsoft, Padrões de Segurança e Guias de Implementação

#### Controles Avançados de Segurança (02-Security/) - Implementação Empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisão completa com framework de segurança de nível empresarial
  - **9 Domínios Abrangentes de Segurança**: Expandido de controles básicos para framework empresarial detalhado
    - Autenticação e Autorização Avançadas com integração ao Microsoft Entra ID
    - Segurança de Tokens e Controles Anti-Passthrough com validação abrangente
    - Controles de Segurança de Sessão com prevenção de sequestro
    - Controles de Segurança Específicos de IA com prevenção de injeção de prompts e envenenamento de ferramentas
    - Prevenção de Ataques Confused Deputy com segurança de proxy OAuth
    - Segurança na Execução de Ferramentas com sandboxing e isolamento
    - Controles de Segurança da Cadeia de Suprimentos com verificação de dependências
    - Controles de Monitoramento e Detecção com integração SIEM
    - Resposta a Incidentes e Recuperação com capacidades automatizadas
  - **Exemplos de Implementação**: Adicionados blocos de configuração YAML detalhados e exemplos de código
  - **Integração com Soluções da Microsoft**: Cobertura abrangente de serviços de segurança do Azure, GitHub Advanced Security e gerenciamento de identidade empresarial

#### Segurança em Tópicos Avançados (05-AdvancedTopics/mcp-security/) - Implementação Pronta para Produção
- **README.md**: Reescrita completa para implementação de segurança empresarial
  - **Alinhamento à Especificação Atual**: Atualizado para a Especificação MCP 2025-06-18 com requisitos obrigatórios de segurança
  - **Autenticação Aprimorada**: Integração ao Microsoft Entra ID com exemplos abrangentes em .NET e Java Spring Security
  - **Integração de Segurança com IA**: Implementação do Microsoft Prompt Shields e Azure Content Safety com exemplos detalhados em Python
  - **Mitigação Avançada de Ameaças**: Exemplos abrangentes de implementação para
    - Prevenção de Ataques Confused Deputy com PKCE e validação de consentimento do usuário
    - Prevenção de Passthrough de Tokens com validação de público e gerenciamento seguro de tokens
    - Prevenção de Sequestro de Sessão com vinculação criptográfica e análise comportamental
  - **Integração de Segurança Empresarial**: Monitoramento com Azure Application Insights, pipelines de detecção de ameaças e segurança da cadeia de suprimentos
  - **Checklist de Implementação**: Controles de segurança obrigatórios vs. recomendados com benefícios do ecossistema de segurança da Microsoft

### Qualidade da Documentação e Alinhamento aos Padrões
- **Referências à Especificação**: Atualizadas todas as referências para a Especificação MCP atual 2025-06-18
- **Ecossistema de Segurança da Microsoft**: Orientação aprimorada de integração em toda a documentação de segurança
- **Implementação Prática**: Adicionados exemplos detalhados de código em .NET, Java e Python com padrões empresariais
- **Organização de Recursos**: Categorização abrangente de documentação oficial, padrões de segurança e guias de implementação
- **Indicadores Visuais**: Marcação clara de requisitos obrigatórios versus práticas recomendadas

#### Conceitos Fundamentais (01-CoreConcepts/) - Modernização Completa
- **Atualização da Versão do Protocolo**: Atualizado para referenciar a Especificação MCP atual de 2025-06-18 com versionamento baseado em data (formato YYYY-MM-DD)
- **Aprimoramento da Arquitetura**: Descrições aprimoradas de Hosts, Clientes e Servidores para refletir os padrões atuais da arquitetura MCP
  - Hosts agora definidos claramente como aplicações de IA que coordenam múltiplas conexões de clientes MCP
  - Clientes descritos como conectores de protocolo que mantêm relações um-para-um com servidores
  - Servidores aprimorados com cenários de implantação local versus remota
- **Reestruturação de Primitivas**: Revisão completa das primitivas de servidor e cliente
  - Primitivas de Servidor: Recursos (fontes de dados), Prompts (modelos), Ferramentas (funções executáveis) com explicações detalhadas e exemplos
  - Primitivas de Cliente: Amostragem (completions de LLM), Elicitação (entrada do usuário), Registro (debug/monitoramento)
  - Atualizado com padrões atuais de descoberta (`*/list`), recuperação (`*/get`) e execução (`*/call`)
- **Arquitetura do Protocolo**: Introdução de um modelo de arquitetura de duas camadas
  - Camada de Dados: Baseada em JSON-RPC 2.0 com gerenciamento de ciclo de vida e primitivas
  - Camada de Transporte: Mecanismos de transporte STDIO (local) e HTTP com SSE (remoto)
- **Estrutura de Segurança**: Princípios abrangentes de segurança, incluindo consentimento explícito do usuário, proteção de privacidade de dados, segurança na execução de ferramentas e segurança na camada de transporte
- **Padrões de Comunicação**: Mensagens do protocolo atualizadas para mostrar fluxos de inicialização, descoberta, execução e notificações
- **Exemplos de Código**: Exemplos multilíngues atualizados (.NET, Java, Python, JavaScript) para refletir os padrões atuais do SDK MCP

#### Segurança (02-Security/) - Revisão Abrangente de Segurança  
- **Alinhamento com Padrões**: Alinhamento completo com os requisitos de segurança da Especificação MCP 2025-06-18
- **Evolução da Autenticação**: Documentada a evolução de servidores OAuth personalizados para delegação de provedores de identidade externos (Microsoft Entra ID)
- **Análise de Ameaças Específicas de IA**: Cobertura aprimorada de vetores modernos de ataque à IA
  - Cenários detalhados de ataques de injeção de prompts com exemplos reais
  - Mecanismos de envenenamento de ferramentas e padrões de ataque "rug pull"
  - Envenenamento de janela de contexto e ataques de confusão de modelo
- **Soluções de Segurança da Microsoft para IA**: Cobertura abrangente do ecossistema de segurança da Microsoft
  - AI Prompt Shields com técnicas avançadas de detecção, destaque e delimitadores
  - Padrões de integração do Azure Content Safety
  - GitHub Advanced Security para proteção da cadeia de suprimentos
- **Mitigação Avançada de Ameaças**: Controles de segurança detalhados para
  - Sequestro de sessão com cenários de ataque específicos do MCP e requisitos criptográficos de ID de sessão
  - Problemas de "deputado confuso" em cenários de proxy MCP com requisitos de consentimento explícito
  - Vulnerabilidades de passagem de token com controles obrigatórios de validação
- **Segurança da Cadeia de Suprimentos**: Cobertura expandida da cadeia de suprimentos de IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros
- **Segurança Fundamental**: Integração aprimorada com padrões de segurança empresarial, incluindo arquitetura de confiança zero e ecossistema de segurança da Microsoft
- **Organização de Recursos**: Links de recursos abrangentes categorizados por tipo (Documentação Oficial, Padrões, Pesquisa, Soluções da Microsoft, Guias de Implementação)

### Melhorias na Qualidade da Documentação
- **Objetivos de Aprendizado Estruturados**: Objetivos de aprendizado aprimorados com resultados específicos e acionáveis
- **Referências Cruzadas**: Adicionados links entre tópicos relacionados de segurança e conceitos fundamentais
- **Informações Atualizadas**: Todas as referências de datas e links de especificações atualizados para os padrões atuais
- **Orientação de Implementação**: Diretrizes específicas e acionáveis de implementação adicionadas em ambas as seções

## 16 de julho de 2025

### Melhorias no README e Navegação
- Navegação do currículo completamente redesenhada no README.md
- Substituídos os tags `<details>` por um formato baseado em tabelas mais acessível
- Criadas opções de layout alternativas na nova pasta "alternative_layouts"
- Adicionados exemplos de navegação em estilo de cartões, abas e acordeão
- Atualizada a seção de estrutura do repositório para incluir todos os arquivos mais recentes
- Melhorada a seção "Como Usar Este Currículo" com recomendações claras
- Links de especificação MCP atualizados para apontar para URLs corretos
- Adicionada a seção de Engenharia de Contexto (5.14) à estrutura do currículo

### Atualizações do Guia de Estudos
- Guia de estudos completamente revisado para alinhar com a estrutura atual do repositório
- Adicionadas novas seções para Clientes MCP e Ferramentas, e Servidores MCP Populares
- Atualizado o Mapa Visual do Currículo para refletir com precisão todos os tópicos
- Descrições aprimoradas de Tópicos Avançados para cobrir todas as áreas especializadas
- Seção de Estudos de Caso atualizada para refletir exemplos reais
- Adicionado este changelog abrangente

### Contribuições da Comunidade (06-CommunityContributions/)
- Adicionadas informações detalhadas sobre servidores MCP para geração de imagens
- Adicionada seção abrangente sobre o uso do Claude no VSCode
- Adicionadas instruções de configuração e uso do cliente terminal Cline
- Seção de clientes MCP atualizada para incluir todas as opções populares de clientes
- Exemplos de contribuição aprimorados com amostras de código mais precisas

### Tópicos Avançados (05-AdvancedTopics/)
- Todos os tópicos especializados organizados em pastas com nomenclatura consistente
- Adicionados materiais e exemplos de engenharia de contexto
- Documentação de integração do agente Foundry adicionada
- Documentação de integração de segurança do Entra ID aprimorada

## 11 de junho de 2025

### Criação Inicial
- Primeira versão do currículo MCP para Iniciantes lançada
- Estrutura básica criada para todas as 10 seções principais
- Implementado Mapa Visual do Currículo para navegação
- Adicionados projetos de exemplo iniciais em várias linguagens de programação

### Introdução (03-GettingStarted/)
- Criados os primeiros exemplos de implementação de servidor
- Adicionadas orientações para desenvolvimento de clientes
- Instruções de integração de clientes LLM incluídas
- Documentação de integração com VS Code adicionada
- Exemplos de servidor com Server-Sent Events (SSE) implementados

### Conceitos Fundamentais (01-CoreConcepts/)
- Explicação detalhada da arquitetura cliente-servidor adicionada
- Documentação criada sobre os principais componentes do protocolo
- Padrões de mensagens no MCP documentados

## 23 de maio de 2025

### Estrutura do Repositório
- Repositório inicializado com estrutura básica de pastas
- Arquivos README criados para cada seção principal
- Infraestrutura de tradução configurada
- Adicionados ativos de imagem e diagramas

### Documentação
- README.md inicial criado com visão geral do currículo
- CODE_OF_CONDUCT.md e SECURITY.md adicionados
- SUPPORT.md configurado com orientações para obter ajuda
- Estrutura preliminar do guia de estudos criada

## 15 de abril de 2025

### Planejamento e Estrutura
- Planejamento inicial para o currículo MCP para Iniciantes
- Objetivos de aprendizado e público-alvo definidos
- Estrutura de 10 seções do currículo delineada
- Estrutura conceitual desenvolvida para exemplos e estudos de caso
- Exemplos de protótipo inicial criados para conceitos-chave

---

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.