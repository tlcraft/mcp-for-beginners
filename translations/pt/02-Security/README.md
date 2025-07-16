<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-16T22:00:11+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pt"
}
-->
# Melhores Práticas de Segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações impulsionadas por IA, mas também introduz desafios de segurança únicos que vão além dos riscos tradicionais de software. Para além de preocupações já estabelecidas como codificação segura, princípio do menor privilégio e segurança da cadeia de fornecimento, o MCP e as cargas de trabalho de IA enfrentam novas ameaças como injeção de prompts, envenenamento de ferramentas, modificação dinâmica de ferramentas, sequestro de sessão, ataques de delegado confuso e vulnerabilidades de passagem de tokens. Estes riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos inesperados do sistema se não forem geridos adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompts, segurança de sessão, problemas de delegado confuso, vulnerabilidades de passagem de tokens e vulnerabilidades na cadeia de fornecimento — e fornece controlos práticos e melhores práticas para os mitigar. Também aprenderá a tirar partido de soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para reforçar a sua implementação MCP. Ao compreender e aplicar estes controlos, pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que os seus sistemas de IA permanecem robustos e confiáveis.

# Objetivos de Aprendizagem

No final desta lição, será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompts, envenenamento de ferramentas, permissões excessivas, sequestro de sessão, problemas de delegado confuso, vulnerabilidades de passagem de tokens e vulnerabilidades na cadeia de fornecimento.
- Descrever e aplicar controlos eficazes para mitigar os riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gestão segura de tokens, controlos de segurança de sessão e verificação da cadeia de fornecimento.
- Compreender e utilizar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho MCP e IA.
- Reconhecer a importância de validar metadados das ferramentas, monitorizar alterações dinâmicas, defender contra ataques indiretos de injeção de prompts e prevenir sequestro de sessão.
- Integrar melhores práticas de segurança estabelecidas — como codificação segura, endurecimento de servidores e arquitetura de zero trust — na sua implementação MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controlos de segurança MCP

Qualquer sistema que tenha acesso a recursos importantes enfrenta desafios de segurança implícitos. Estes desafios podem geralmente ser resolvidos através da aplicação correta de controlos e conceitos fundamentais de segurança. Como o MCP é uma especificação recentemente definida, está a evoluir rapidamente e, à medida que o protocolo avança, os controlos de segurança nele incorporados irão amadurecer, permitindo uma melhor integração com arquiteturas empresariais e melhores práticas de segurança já estabelecidas.

A pesquisa publicada no [Microsoft Digital Defense Report](https://aka.ms/mddr) indica que 98% das violações reportadas poderiam ser evitadas com uma higiene de segurança robusta, e a melhor proteção contra qualquer tipo de violação é garantir que a sua higiene de segurança básica, melhores práticas de codificação segura e segurança da cadeia de fornecimento estejam corretas — essas práticas testadas e comprovadas continuam a ter o maior impacto na redução do risco de segurança.

Vamos analisar algumas formas de começar a abordar os riscos de segurança ao adotar o MCP.

> **Note:** A informação seguinte está correta até **29 de maio de 2025**. O protocolo MCP está em constante evolução, e implementações futuras podem introduzir novos padrões e controlos de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [Especificação MCP](https://spec.modelcontextprotocol.io/) e o repositório oficial [MCP GitHub](https://github.com/modelcontextprotocol) e a [página de melhores práticas de segurança](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declaração do problema  
A especificação original do MCP assumia que os desenvolvedores escreveriam o seu próprio servidor de autenticação. Isto exigia conhecimento de OAuth e das restrições de segurança relacionadas. Os servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerindo diretamente a autenticação do utilizador necessária, em vez de a delegar para um serviço externo como o Microsoft Entra ID. A partir de **26 de abril de 2025**, uma atualização da especificação MCP permite que os servidores MCP deleguem a autenticação do utilizador a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e à aplicação incorreta de controlos de acesso.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para se fazer passar pelo servidor MCP e aceder a recursos e dados do serviço para o qual o token OAuth foi emitido.

#### Passagem de Token
A passagem de token é explicitamente proibida na especificação de autorização, pois introduz vários riscos de segurança, incluindo:

#### Contorno de Controlos de Segurança
O servidor MCP ou APIs a jusante podem implementar controlos importantes de segurança como limitação de taxa, validação de pedidos ou monitorização de tráfego, que dependem do público do token ou outras restrições de credenciais. Se os clientes conseguirem obter e usar tokens diretamente com as APIs a jusante sem que o servidor MCP os valide corretamente ou assegure que os tokens foram emitidos para o serviço correto, estes controlos são contornados.

#### Problemas de Responsabilização e Auditoria
O servidor MCP não conseguirá identificar ou distinguir entre clientes MCP quando estes chamam com um token de acesso emitido a montante que pode ser opaco para o servidor MCP.  
Os registos do servidor de recursos a jusante podem mostrar pedidos que parecem vir de uma fonte diferente com uma identidade diferente, em vez do servidor MCP que está a encaminhar os tokens.  
Ambos os fatores dificultam a investigação de incidentes, controlos e auditorias.  
Se o servidor MCP passar tokens sem validar as suas declarações (por exemplo, funções, privilégios ou público) ou outros metadados, um ator malicioso na posse de um token roubado pode usar o servidor como proxy para exfiltração de dados.

#### Problemas de Limite de Confiança
O servidor de recursos a jusante concede confiança a entidades específicas. Esta confiança pode incluir pressupostos sobre a origem ou padrões de comportamento do cliente. Quebrar este limite de confiança pode levar a problemas inesperados.  
Se o token for aceite por múltiplos serviços sem validação adequada, um atacante que comprometa um serviço pode usar o token para aceder a outros serviços ligados.

#### Risco de Compatibilidade Futura
Mesmo que um servidor MCP comece hoje como um "proxy puro", poderá precisar de adicionar controlos de segurança mais tarde. Começar com uma separação adequada do público do token facilita a evolução do modelo de segurança.

### Controlos mitigadores

**Os servidores MCP NÃO DEVEM aceitar quaisquer tokens que não tenham sido explicitamente emitidos para o servidor MCP**

- **Rever e Endurecer a Lógica de Autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas os utilizadores e clientes pretendidos possam aceder a recursos sensíveis. Para orientação prática, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar Práticas Seguras de Token:** Siga as [melhores práticas da Microsoft para validação e duração de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar o uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de tokens.
- **Proteger o Armazenamento de Tokens:** Armazene sempre os tokens de forma segura e utilize encriptação para os proteger em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema
Os servidores MCP podem ter sido concedidas permissões excessivas para o serviço/recurso a que acedem. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA que se conecta a um repositório de dados empresarial deve ter acesso limitado aos dados de vendas e não deve poder aceder a todos os ficheiros do repositório. Relembrando o princípio do menor privilégio (um dos princípios de segurança mais antigos), nenhum recurso deve ter permissões superiores às necessárias para executar as tarefas para as quais foi destinado. A IA apresenta um desafio acrescido nesta área porque, para ser flexível, pode ser difícil definir exatamente as permissões necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir a exfiltração ou alteração de dados que o servidor MCP não deveria poder aceder. Isto pode também constituir um problema de privacidade se os dados forem informações pessoalmente identificáveis (PII).

### Controlos mitigadores
- **Aplicar o Princípio do Menor Privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar as suas tarefas. Reveja e atualize regularmente estas permissões para garantir que não excedem o necessário. Para orientação detalhada, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controlo de Acesso Baseado em Funções (RBAC):** Atribua ao servidor MCP funções que sejam estritamente limitadas a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorizar e Auditar Permissões:** Monitorize continuamente o uso das permissões e audite os registos de acesso para detetar e corrigir rapidamente privilégios excessivos ou não utilizados.

# Ataques indiretos de injeção de prompts

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionadas. Estes riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt:** Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo com que o sistema de IA execute ações não intencionadas ou divulgue dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas:** Atacantes manipulam metadados das ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controlos de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt Cross-Domain:** Instruções maliciosas são inseridas em documentos, páginas web ou emails, que são depois processados pela IA, levando a fugas ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls):** Definições de ferramentas podem ser alteradas após aprovação do utilizador, introduzindo novos comportamentos maliciosos sem o conhecimento do utilizador.

Estas vulnerabilidades destacam a necessidade de validação robusta, monitorização e controlos de segurança ao integrar servidores MCP e ferramentas no seu ambiente. Para uma análise mais aprofundada, consulte as referências acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pt.png)

**Injeção Indireta de Prompt** (também conhecida como injeção de prompt cross-domain ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Model Context Protocol (MCP). Neste ataque, instruções maliciosas são ocultadas em conteúdos externos — como documentos, páginas web ou emails. Quando o sistema de IA processa este conteúdo, pode interpretar as instruções embutidas como comandos legítimos do utilizador, resultando em ações não intencionadas como fuga de dados, geração de conteúdo prejudicial ou manipulação das interações do utilizador. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa deste ataque é o **Envenenamento de Ferramentas**. Aqui, os atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem destes metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas de ferramentas não autorizadas ou contornar controlos de segurança. Estas manipulações são frequentemente invisíveis para os utilizadores finais, mas podem ser interpretadas e executadas pelo sistema de IA. Este risco é agravado em ambientes de servidores MCP hospedados, onde as definições das ferramentas podem ser atualizadas após aprovação do utilizador — um cenário por vezes referido como "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nestes casos, uma ferramenta que antes era segura pode ser modificada posteriormente para realizar ações maliciosas, como exfiltração de dados ou alteração do comportamento do sistema, sem o conhecimento do utilizador. Para mais informações sobre este vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pt.png)

## Riscos
Ações não intencionadas da IA apresentam vários riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controlos mitigadores
### Uso de prompt shields para proteger contra ataques indiretos de injeção de prompt
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompt diretos e indiretos. Ajudam através de:

1.  **Deteção e Filtragem:** Os Prompt Shields utilizam algoritmos avançados de machine learning e processamento de linguagem natural para detetar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou emails.
    
2.  **Spotlighting:** Esta técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma a torná-lo mais relevante para o modelo, o Spotlighting garante que a IA consegue identificar melhor e ignorar instruções maliciosas.
    
3.  **Delimitadores e Datamarking:** Incluir delimitadores na mensagem do sistema define explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar as entradas do utilizador de conteúdos externos potencialmente prejudiciais. O datamarking estende este conceito usando marcadores especiais para destacar os limites entre dados confiáveis e não confiáveis.
    
4.  **Monitorização Contínua e Atualizações:** A Microsoft monitoriza e atualiza continuamente os Prompt Shields para responder a ameaças novas e em evolução. Esta abordagem proativa garante que as defesas permanecem eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Os Prompt Shields fazem parte da suíte mais ampla Azure AI Content Safety, que oferece ferramentas adicionais para detetar tentativas de jailbreak, conteúdos prejudiciais e outros riscos de segurança em aplicações de IA.

Pode ler mais sobre os AI prompt shields na [documentação do Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pt.png)

# Problema do Delegado Confuso

### Declaração do problema
O problema do confuso representante é uma vulnerabilidade de segurança que ocorre quando um servidor MCP atua como proxy entre clientes MCP e APIs de terceiros. Esta vulnerabilidade pode ser explorada quando o servidor MCP utiliza um ID de cliente estático para autenticar-se junto de um servidor de autorização de terceiros que não suporta registo dinâmico de clientes.

### Riscos

- **Bypass de consentimento baseado em cookies**: Se um utilizador já se autenticou anteriormente através do servidor proxy MCP, um servidor de autorização de terceiros pode definir um cookie de consentimento no navegador do utilizador. Um atacante pode explorar isto enviando ao utilizador um link malicioso com um pedido de autorização manipulado que contém um URI de redirecionamento malicioso.
- **Roubo do código de autorização**: Quando o utilizador clica no link malicioso, o servidor de autorização de terceiros pode ignorar o ecrã de consentimento devido ao cookie existente, e o código de autorização pode ser redirecionado para o servidor do atacante.
- **Acesso não autorizado à API**: O atacante pode trocar o código de autorização roubado por tokens de acesso e personificar o utilizador para aceder à API de terceiros sem aprovação explícita.

### Controlo de mitigação

- **Requisitos explícitos de consentimento**: Os servidores proxy MCP que utilizam IDs de cliente estáticos **DEVEM** obter o consentimento do utilizador para cada cliente registado dinamicamente antes de encaminhar para servidores de autorização de terceiros.
- **Implementação correta do OAuth**: Seguir as melhores práticas de segurança do OAuth 2.1, incluindo o uso de desafios de código (PKCE) para pedidos de autorização, para prevenir ataques de interceção.
- **Validação do cliente**: Implementar validação rigorosa dos URIs de redirecionamento e identificadores de cliente para evitar exploração por atores maliciosos.


# Vulnerabilidades de passagem de token

### Declaração do problema

"Passagem de token" é um anti-padrão onde um servidor MCP aceita tokens de um cliente MCP sem validar que os tokens foram emitidos corretamente para o próprio servidor MCP, e depois "os passa" para APIs a jusante. Esta prática viola explicitamente a especificação de autorização MCP e introduz riscos graves de segurança.

### Riscos

- **Circunvenção de controlos de segurança**: Os clientes podem contornar controlos importantes como limitação de taxa, validação de pedidos ou monitorização de tráfego se puderem usar tokens diretamente com APIs a jusante sem validação adequada.
- **Problemas de responsabilidade e auditoria**: O servidor MCP não conseguirá identificar ou distinguir entre clientes MCP quando estes usam tokens de acesso emitidos a montante, dificultando a investigação de incidentes e auditorias.
- **Exfiltração de dados**: Se os tokens forem passados sem validação adequada das claims, um ator malicioso com um token roubado pode usar o servidor como proxy para exfiltração de dados.
- **Violações da fronteira de confiança**: Os servidores de recursos a jusante podem conceder confiança a entidades específicas com base em suposições sobre a origem ou padrões de comportamento. Quebrar esta fronteira de confiança pode levar a problemas de segurança inesperados.
- **Uso indevido de tokens multi-serviço**: Se os tokens forem aceites por múltiplos serviços sem validação adequada, um atacante que comprometa um serviço pode usar o token para aceder a outros serviços ligados.

### Controlo de mitigação

- **Validação de tokens**: Os servidores MCP **NÃO DEVEM** aceitar tokens que não tenham sido explicitamente emitidos para o próprio servidor MCP.
- **Verificação da audiência**: Validar sempre que os tokens têm a claim de audiência correta que corresponde à identidade do servidor MCP.
- **Gestão adequada do ciclo de vida dos tokens**: Implementar tokens de acesso de curta duração e práticas adequadas de rotação de tokens para reduzir o risco de roubo e uso indevido.


# Sequestro de sessão

### Declaração do problema

O sequestro de sessão é um vetor de ataque onde um cliente recebe um ID de sessão do servidor, e uma parte não autorizada obtém e usa esse mesmo ID de sessão para personificar o cliente original e realizar ações não autorizadas em seu nome. Isto é particularmente preocupante em servidores HTTP stateful que tratam pedidos MCP.

### Riscos

- **Injeção de prompt por sequestro de sessão**: Um atacante que obtenha um ID de sessão pode enviar eventos maliciosos para um servidor que partilha o estado da sessão com o servidor ao qual o cliente está ligado, potencialmente desencadeando ações prejudiciais ou acedendo a dados sensíveis.
- **Personificação por sequestro de sessão**: Um atacante com um ID de sessão roubado pode fazer chamadas diretamente ao servidor MCP, contornando a autenticação e sendo tratado como o utilizador legítimo.
- **Streams retomáveis comprometidos**: Quando um servidor suporta redelivery/streams retomáveis, um atacante pode terminar um pedido prematuramente, levando a que este seja retomado mais tarde pelo cliente original com conteúdo potencialmente malicioso.

### Controlo de mitigação

- **Verificação de autorização**: Os servidores MCP que implementam autorização **DEVEM** verificar todos os pedidos recebidos e **NÃO DEVEM** usar sessões para autenticação.
- **IDs de sessão seguros**: Os servidores MCP **DEVEM** usar IDs de sessão seguros e não determinísticos, gerados com geradores de números aleatórios seguros. Evitar identificadores previsíveis ou sequenciais.
- **Ligação da sessão ao utilizador**: Os servidores MCP **DEVEM** ligar os IDs de sessão a informações específicas do utilizador, combinando o ID de sessão com informação única do utilizador autorizado (como o seu ID interno) usando um formato como `
<user_id>:<session_id>`.
- **Expiração da sessão**: Implementar expiração e rotação adequadas das sessões para limitar a janela de vulnerabilidade caso um ID de sessão seja comprometido.
- **Segurança no transporte**: Usar sempre HTTPS para toda a comunicação para evitar a interceção do ID de sessão.


# Segurança da cadeia de fornecimento

A segurança da cadeia de fornecimento continua a ser fundamental na era da IA, mas o âmbito do que constitui a sua cadeia de fornecimento expandiu-se. Para além dos pacotes de código tradicionais, deve agora verificar e monitorizar rigorosamente todos os componentes relacionados com IA, incluindo modelos base, serviços de embeddings, fornecedores de contexto e APIs de terceiros. Cada um destes pode introduzir vulnerabilidades ou riscos se não forem geridos corretamente.

**Práticas chave de segurança da cadeia de fornecimento para IA e MCP:**
- **Verificar todos os componentes antes da integração:** Isto inclui não só bibliotecas open-source, mas também modelos de IA, fontes de dados e APIs externas. Verifique sempre a proveniência, licenciamento e vulnerabilidades conhecidas.
- **Manter pipelines de deployment seguros:** Use pipelines CI/CD automatizados com análise de segurança integrada para detetar problemas precocemente. Assegure que apenas artefactos confiáveis são implantados em produção.
- **Monitorizar e auditar continuamente:** Implemente monitorização contínua para todas as dependências, incluindo modelos e serviços de dados, para detetar novas vulnerabilidades ou ataques à cadeia de fornecimento.
- **Aplicar o princípio do menor privilégio e controlos de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do seu servidor MCP.
- **Responder rapidamente a ameaças:** Tenha um processo para corrigir ou substituir componentes comprometidos, e para rodar segredos ou credenciais se for detetada uma violação.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece funcionalidades como scanning de segredos, scanning de dependências e análise CodeQL. Estas ferramentas integram-se com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar as equipas a identificar e mitigar vulnerabilidades tanto no código como nos componentes da cadeia de fornecimento de IA.

A Microsoft também implementa práticas extensivas de segurança da cadeia de fornecimento internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Melhores práticas de segurança estabelecidas que irão reforçar a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança existente do ambiente da sua organização onde está construída, por isso, ao considerar a segurança do MCP como componente dos seus sistemas globais de IA, recomenda-se que melhore a sua postura de segurança geral existente. Os seguintes controlos de segurança estabelecidos são especialmente relevantes:

-   Melhores práticas de codificação segura na sua aplicação de IA - proteger contra [o OWASP Top 10](https://owasp.org/www-project-top-ten/), o [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras de ponta a ponta entre todos os componentes da aplicação, etc.
-   Endurecimento do servidor -- usar MFA sempre que possível, manter as atualizações em dia, integrar o servidor com um fornecedor de identidade de terceiros para acesso, etc.
-   Manter dispositivos, infraestrutura e aplicações atualizados com patches
-   Monitorização de segurança -- implementar logging e monitorização de uma aplicação de IA (incluindo clientes/servidores MCP) e enviar esses logs para um SIEM central para deteção de atividades anómalas
-   Arquitetura de confiança zero -- isolar componentes via controlos de rede e identidade de forma lógica para minimizar movimentos laterais caso uma aplicação de IA seja comprometida.

# Principais conclusões

- Os fundamentos de segurança continuam críticos: codificação segura, princípio do menor privilégio, verificação da cadeia de fornecimento e monitorização contínua são essenciais para cargas de trabalho MCP e IA.
- O MCP introduz novos riscos — como injeção de prompt, envenenamento de ferramentas, sequestro de sessão, problemas de confuso representante, vulnerabilidades de passagem de token e permissões excessivas — que requerem controlos tradicionais e específicos para IA.
- Use práticas robustas de autenticação, autorização e gestão de tokens, aproveitando fornecedores de identidade externos como o Microsoft Entra ID sempre que possível.
- Proteja-se contra injeção indireta de prompt e envenenamento de ferramentas validando metadados das ferramentas, monitorizando alterações dinâmicas e usando soluções como o Microsoft Prompt Shields.
- Implemente gestão segura de sessões usando IDs de sessão não determinísticos, ligando sessões a identidades de utilizador e nunca usando sessões para autenticação.
- Previna ataques de confuso representante exigindo consentimento explícito do utilizador para cada cliente registado dinamicamente e implementando práticas corretas de segurança OAuth.
- Evite vulnerabilidades de passagem de token garantindo que os servidores MCP só aceitam tokens emitidos explicitamente para eles e validam adequadamente as claims dos tokens.
- Trate todos os componentes da sua cadeia de fornecimento de IA — incluindo modelos, embeddings e fornecedores de contexto — com o mesmo rigor que as dependências de código.
- Mantenha-se atualizado com as especificações MCP em evolução e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos adicionais

## Recursos externos
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Documentos adicionais de segurança

Para orientações de segurança mais detalhadas, consulte estes documentos:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Lista abrangente de melhores práticas de segurança para implementações MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Exemplos de implementação para integrar Azure Content Safety com servidores MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Controlo e técnicas de segurança mais recentes para proteger implementações MCP
- [MCP Best Practices](./mcp-best-practices.md) - Guia rápido de referência para segurança MCP

### Próximo

Próximo: [Capítulo 3: Começar](../03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.