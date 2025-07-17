<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T01:09:35+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "br"
}
-->
# Práticas recomendadas de segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações baseadas em IA, mas também introduz desafios de segurança únicos que vão além dos riscos tradicionais de software. Além das preocupações já estabelecidas, como codificação segura, princípio do menor privilégio e segurança da cadeia de suprimentos, o MCP e as cargas de trabalho de IA enfrentam novas ameaças, como injeção de prompt, envenenamento de ferramentas, modificação dinâmica de ferramentas, sequestro de sessão, ataques de delegado confuso e vulnerabilidades de passagem de token. Esses riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos inesperados do sistema se não forem gerenciados adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompt, segurança de sessão, problemas de delegado confuso, vulnerabilidades de passagem de token e vulnerabilidades na cadeia de suprimentos — e oferece controles práticos e melhores práticas para mitigá-los. Você também aprenderá a utilizar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para fortalecer sua implementação do MCP. Ao entender e aplicar esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompt, envenenamento de ferramentas, permissões excessivas, sequestro de sessão, problemas de delegado confuso, vulnerabilidades de passagem de token e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes para mitigar os riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gerenciamento seguro de tokens, controles de segurança de sessão e verificação da cadeia de suprimentos.
- Entender e aproveitar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para proteger cargas de trabalho MCP e de IA.
- Reconhecer a importância de validar metadados de ferramentas, monitorar mudanças dinâmicas, defender-se contra ataques indiretos de injeção de prompt e prevenir sequestro de sessão.
- Integrar as melhores práticas de segurança estabelecidas — como codificação segura, fortalecimento de servidores e arquitetura de zero trust — em sua implementação do MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança do MCP

Qualquer sistema que tenha acesso a recursos importantes apresenta desafios implícitos de segurança. Esses desafios geralmente podem ser tratados por meio da aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP é uma especificação recém-definida, ela está mudando rapidamente à medida que o protocolo evolui. Eventualmente, os controles de segurança nele contidos irão amadurecer, permitindo uma melhor integração com arquiteturas e melhores práticas de segurança corporativas já estabelecidas.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) indicam que 98% das violações relatadas poderiam ser evitadas com uma higiene de segurança robusta, e a melhor proteção contra qualquer tipo de violação é garantir uma base sólida de higiene de segurança, melhores práticas de codificação segura e segurança da cadeia de suprimentos — essas práticas testadas e comprovadas ainda são as que mais impactam na redução do risco de segurança.

Vamos analisar algumas formas de começar a abordar os riscos de segurança ao adotar o MCP.

> **Note:** As informações a seguir estão corretas até **29 de maio de 2025**. O protocolo MCP está em constante evolução, e implementações futuras podem introduzir novos padrões e controles de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [Especificação MCP](https://spec.modelcontextprotocol.io/), o repositório oficial no [GitHub MCP](https://github.com/modelcontextprotocol) e a [página de melhores práticas de segurança](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declaração do problema  
A especificação original do MCP assumia que os desenvolvedores escreveriam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Os servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerenciando a autenticação do usuário diretamente, em vez de delegá-la a um serviço externo, como o Microsoft Entra ID. A partir de **26 de abril de 2025**, uma atualização na especificação do MCP permite que servidores MCP deleguem a autenticação do usuário a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e aplicação incorreta dos controles de acesso.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth foi emitido.

#### Passagem de Token
A passagem de token é explicitamente proibida na especificação de autorização, pois introduz diversos riscos de segurança, incluindo:

#### Contorno de Controles de Segurança
O servidor MCP ou APIs a jusante podem implementar controles importantes de segurança, como limitação de taxa, validação de requisições ou monitoramento de tráfego, que dependem do público do token ou outras restrições de credenciais. Se os clientes puderem obter e usar tokens diretamente com as APIs a jusante sem que o servidor MCP os valide corretamente ou garanta que os tokens foram emitidos para o serviço correto, esses controles são contornados.

#### Problemas de Responsabilização e Auditoria
O servidor MCP não será capaz de identificar ou distinguir entre clientes MCP quando eles fizerem chamadas com um token de acesso emitido a montante, que pode ser opaco para o servidor MCP.  
Os logs do servidor de recursos a jusante podem mostrar requisições que parecem vir de uma fonte diferente, com uma identidade diferente, em vez do servidor MCP que está realmente encaminhando os tokens.  
Ambos os fatores dificultam a investigação de incidentes, controles e auditorias.  
Se o servidor MCP passar tokens sem validar suas reivindicações (por exemplo, funções, privilégios ou público) ou outros metadados, um agente malicioso em posse de um token roubado pode usar o servidor como um proxy para exfiltração de dados.

#### Problemas de Limite de Confiança
O servidor de recursos a jusante concede confiança a entidades específicas. Essa confiança pode incluir suposições sobre a origem ou padrões de comportamento do cliente. Quebrar esse limite de confiança pode levar a problemas inesperados.  
Se o token for aceito por vários serviços sem validação adequada, um invasor que comprometer um serviço pode usar o token para acessar outros serviços conectados.

#### Risco de Compatibilidade Futura
Mesmo que um servidor MCP comece hoje como um "proxy puro", ele pode precisar adicionar controles de segurança posteriormente. Começar com a separação adequada do público do token facilita a evolução do modelo de segurança.

### Controles mitigadores

**Servidores MCP NÃO DEVEM aceitar tokens que não tenham sido explicitamente emitidos para o servidor MCP**

- **Revisar e Fortalecer a Lógica de Autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes autorizados possam acessar recursos sensíveis. Para orientações práticas, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar Práticas Seguras de Token:** Siga as [melhores práticas da Microsoft para validação e tempo de vida de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar o uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de tokens.
- **Proteger o Armazenamento de Tokens:** Sempre armazene tokens de forma segura e use criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema  
Servidores MCP podem ter recebido permissões excessivas para o serviço/recurso que estão acessando. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA conectada a um repositório de dados corporativo deve ter acesso limitado aos dados de vendas e não deve poder acessar todos os arquivos do repositório. Retomando o princípio do menor privilégio (um dos princípios de segurança mais antigos), nenhum recurso deve ter permissões além do necessário para executar as tarefas para as quais foi designado. A IA apresenta um desafio maior nesse aspecto, pois para garantir flexibilidade, pode ser difícil definir exatamente as permissões necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir a exfiltração ou alteração de dados que o servidor MCP não deveria acessar. Isso também pode representar um problema de privacidade se os dados forem informações pessoais identificáveis (PII).

### Controles mitigadores  
- **Aplicar o Princípio do Menor Privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar suas tarefas. Revise e atualize essas permissões regularmente para garantir que não excedam o necessário. Para orientações detalhadas, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controle de Acesso Baseado em Funções (RBAC):** Atribua ao servidor MCP funções com escopo restrito a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorar e Auditar Permissões:** Monitore continuamente o uso de permissões e audite os logs de acesso para detectar e corrigir privilégios excessivos ou não utilizados rapidamente.

# Ataques indiretos de injeção de prompt

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt:** Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo com que o sistema de IA execute ações não intencionais ou vaze dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas:** Atacantes manipulam metadados de ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt Cross-Domain:** Instruções maliciosas são inseridas em documentos, páginas web ou e-mails, que são então processados pela IA, levando a vazamento ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls):** Definições de ferramentas podem ser alteradas após a aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento do usuário.

Essas vulnerabilidades destacam a necessidade de validação robusta, monitoramento e controles de segurança ao integrar servidores MCP e ferramentas ao seu ambiente. Para um aprofundamento, consulte as referências acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.br.png)

**Injeção Indireta de Prompt** (também conhecida como injeção de prompt cross-domain ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Model Context Protocol (MCP). Nesse ataque, instruções maliciosas são ocultadas em conteúdos externos — como documentos, páginas web ou e-mails. Quando o sistema de IA processa esse conteúdo, pode interpretar as instruções embutidas como comandos legítimos do usuário, resultando em ações não intencionais, como vazamento de dados, geração de conteúdo prejudicial ou manipulação das interações do usuário. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Envenenamento de Ferramentas**. Aqui, atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem desses metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas não autorizadas ou contornar controles de segurança. Essas manipulações geralmente são invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é maior em ambientes hospedados de servidores MCP, onde as definições de ferramentas podem ser atualizadas após a aprovação do usuário — um cenário às vezes chamado de "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta que antes era segura pode ser modificada para realizar ações maliciosas, como exfiltração de dados ou alteração do comportamento do sistema, sem o conhecimento do usuário. Para mais informações sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.br.png)

## Riscos  
Ações não intencionais da IA apresentam diversos riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controles mitigadores  
### Usando prompt shields para proteger contra ataques indiretos de injeção de prompt
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques diretos e indiretos de injeção de prompt. Eles ajudam por meio de:

1.  **Detecção e Filtragem:** Prompt Shields usam algoritmos avançados de aprendizado de máquina e processamento de linguagem natural para detectar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou e-mails.
    
2.  **Spotlighting:** Essa técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma que fique mais relevante para o modelo, o Spotlighting garante que a IA possa identificar melhor e ignorar instruções maliciosas.
    
3.  **Delimitadores e Marcação de Dados:** Incluir delimitadores na mensagem do sistema define explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar as entradas do usuário de conteúdos externos potencialmente prejudiciais. A marcação de dados estende esse conceito usando marcadores especiais para destacar os limites entre dados confiáveis e não confiáveis.
    
4.  **Monitoramento Contínuo e Atualizações:** A Microsoft monitora e atualiza continuamente os Prompt Shields para enfrentar novas e evolutivas ameaças. Essa abordagem proativa garante que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Prompt Shields fazem parte do conjunto mais amplo Azure AI Content Safety, que oferece ferramentas adicionais para detectar tentativas de jailbreak, conteúdo prejudicial e outros riscos de segurança em aplicações de IA.

Você pode ler mais sobre AI prompt shields na [documentação do Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.br.png)

# Problema do Delegado Confuso

### Declaração do problema
O problema do delegado confuso é uma vulnerabilidade de segurança que ocorre quando um servidor MCP atua como um proxy entre clientes MCP e APIs de terceiros. Essa vulnerabilidade pode ser explorada quando o servidor MCP usa um ID de cliente estático para autenticar-se em um servidor de autorização de terceiros que não suporta registro dinâmico de clientes.

### Riscos

- **Bypass de consentimento baseado em cookie**: Se um usuário já autenticou-se anteriormente através do servidor proxy MCP, um servidor de autorização de terceiros pode definir um cookie de consentimento no navegador do usuário. Um atacante pode explorar isso enviando ao usuário um link malicioso com uma solicitação de autorização manipulada contendo um URI de redirecionamento malicioso.
- **Roubo do código de autorização**: Quando o usuário clica no link malicioso, o servidor de autorização de terceiros pode pular a tela de consentimento devido ao cookie existente, e o código de autorização pode ser redirecionado para o servidor do atacante.
- **Acesso não autorizado à API**: O atacante pode trocar o código de autorização roubado por tokens de acesso e se passar pelo usuário para acessar a API de terceiros sem aprovação explícita.

### Controles mitigadores

- **Requisitos de consentimento explícito**: Servidores proxy MCP que usam IDs de cliente estáticos **DEVEM** obter o consentimento do usuário para cada cliente registrado dinamicamente antes de encaminhar para servidores de autorização de terceiros.
- **Implementação adequada do OAuth**: Siga as melhores práticas de segurança do OAuth 2.1, incluindo o uso de desafios de código (PKCE) para solicitações de autorização, a fim de evitar ataques de interceptação.
- **Validação do cliente**: Implemente validação rigorosa dos URIs de redirecionamento e identificadores de cliente para evitar exploração por atores maliciosos.


# Vulnerabilidades de passagem de token

### Declaração do problema

"Passagem de token" é um anti-padrão onde um servidor MCP aceita tokens de um cliente MCP sem validar se os tokens foram devidamente emitidos para o próprio servidor MCP, e então os "passa adiante" para APIs downstream. Essa prática viola explicitamente a especificação de autorização MCP e introduz riscos sérios de segurança.

### Riscos

- **Circunvenção de controles de segurança**: Clientes podem burlar controles importantes como limitação de taxa, validação de requisições ou monitoramento de tráfego se puderem usar tokens diretamente com APIs downstream sem validação adequada.
- **Problemas de responsabilidade e auditoria**: O servidor MCP não conseguirá identificar ou distinguir entre clientes MCP quando estes usarem tokens de acesso emitidos upstream, dificultando investigações e auditorias de incidentes.
- **Exfiltração de dados**: Se tokens forem passados sem validação adequada das claims, um ator malicioso com um token roubado poderia usar o servidor como proxy para exfiltração de dados.
- **Violações da fronteira de confiança**: Servidores de recursos downstream podem conceder confiança a entidades específicas com base em suposições sobre origem ou padrões de comportamento. Quebrar essa fronteira pode levar a problemas de segurança inesperados.
- **Uso indevido de tokens multi-serviço**: Se tokens forem aceitos por múltiplos serviços sem validação adequada, um atacante que comprometer um serviço pode usar o token para acessar outros serviços conectados.

### Controles mitigadores

- **Validação de tokens**: Servidores MCP **NÃO DEVEM** aceitar tokens que não tenham sido explicitamente emitidos para o próprio servidor MCP.
- **Verificação da audiência**: Sempre valide se os tokens possuem a claim de audiência correta que corresponda à identidade do servidor MCP.
- **Gerenciamento adequado do ciclo de vida do token**: Implemente tokens de acesso de curta duração e práticas adequadas de rotação de tokens para reduzir o risco de roubo e uso indevido.


# Sequestro de sessão

### Declaração do problema

Sequestro de sessão é um vetor de ataque onde um cliente recebe um ID de sessão do servidor, e uma parte não autorizada obtém e usa esse mesmo ID para se passar pelo cliente original e realizar ações não autorizadas em seu nome. Isso é especialmente preocupante em servidores HTTP stateful que lidam com requisições MCP.

### Riscos

- **Injeção de prompt via sequestro de sessão**: Um atacante que obtiver um ID de sessão pode enviar eventos maliciosos para um servidor que compartilha estado de sessão com o servidor ao qual o cliente está conectado, potencialmente acionando ações prejudiciais ou acessando dados sensíveis.
- **Impersonificação via sequestro de sessão**: Um atacante com um ID de sessão roubado pode fazer chamadas diretamente ao servidor MCP, ignorando a autenticação e sendo tratado como o usuário legítimo.
- **Streams retomáveis comprometidos**: Quando um servidor suporta redelivery/streams retomáveis, um atacante pode terminar uma requisição prematuramente, levando a que ela seja retomada depois pelo cliente original com conteúdo potencialmente malicioso.

### Controles mitigadores

- **Verificação de autorização**: Servidores MCP que implementam autorização **DEVEM** verificar todas as requisições recebidas e **NÃO DEVEM** usar sessões para autenticação.
- **IDs de sessão seguros**: Servidores MCP **DEVEM** usar IDs de sessão seguros e não determinísticos, gerados com geradores de números aleatórios seguros. Evite identificadores previsíveis ou sequenciais.
- **Vinculação de sessão específica ao usuário**: Servidores MCP **DEVEM** vincular IDs de sessão a informações específicas do usuário, combinando o ID da sessão com informações únicas do usuário autorizado (como seu ID interno) usando um formato como `
<user_id>:<session_id>`.
- **Expiração da sessão**: Implemente expiração e rotação adequadas das sessões para limitar a janela de vulnerabilidade caso um ID de sessão seja comprometido.
- **Segurança no transporte**: Use sempre HTTPS para toda comunicação para evitar interceptação do ID de sessão.


# Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, agora é necessário verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um deles pode introduzir vulnerabilidades ou riscos se não for gerenciado adequadamente.

**Práticas-chave de segurança da cadeia de suprimentos para IA e MCP:**
- **Verifique todos os componentes antes da integração:** Isso inclui não apenas bibliotecas open-source, mas também modelos de IA, fontes de dados e APIs externas. Sempre verifique a proveniência, licenciamento e vulnerabilidades conhecidas.
- **Mantenha pipelines de implantação seguros:** Use pipelines CI/CD automatizados com varredura de segurança integrada para detectar problemas cedo. Garanta que apenas artefatos confiáveis sejam implantados em produção.
- **Monitore e audite continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques à cadeia de suprimentos.
- **Aplique o princípio do menor privilégio e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do seu servidor MCP.
- **Responda rapidamente a ameaças:** Tenha um processo para corrigir ou substituir componentes comprometidos, e para rotacionar segredos ou credenciais caso uma violação seja detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece recursos como varredura de segredos, varredura de dependências e análise CodeQL. Essas ferramentas se integram com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades tanto no código quanto nos componentes da cadeia de suprimentos de IA.

A Microsoft também implementa práticas extensas de segurança da cadeia de suprimentos internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Melhores práticas de segurança estabelecidas que elevarão a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança existente do ambiente da sua organização sobre o qual é construída, portanto, ao considerar a segurança do MCP como um componente dos seus sistemas de IA, recomenda-se elevar a postura geral de segurança já existente. Os seguintes controles de segurança estabelecidos são especialmente relevantes:

-   Melhores práticas de codificação segura na sua aplicação de IA - proteja-se contra [o OWASP Top 10](https://owasp.org/www-project-top-ten/), o [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras de ponta a ponta entre todos os componentes da aplicação, etc.
-   Endurecimento do servidor -- use MFA sempre que possível, mantenha as atualizações em dia, integre o servidor com um provedor de identidade terceirizado para acesso, etc.
-   Mantenha dispositivos, infraestrutura e aplicações atualizados com patches
-   Monitoramento de segurança -- implemente logging e monitoramento da aplicação de IA (incluindo clientes/servidores MCP) e envie esses logs para um SIEM central para detecção de atividades anômalas
-   Arquitetura de zero trust -- isole componentes via controles de rede e identidade de forma lógica para minimizar movimentos laterais caso uma aplicação de IA seja comprometida.

# Principais conclusões

- Fundamentos de segurança continuam críticos: codificação segura, princípio do menor privilégio, verificação da cadeia de suprimentos e monitoramento contínuo são essenciais para cargas de trabalho MCP e IA.
- MCP introduz novos riscos — como injeção de prompt, envenenamento de ferramentas, sequestro de sessão, problemas de delegado confuso, vulnerabilidades de passagem de token e permissões excessivas — que exigem controles tradicionais e específicos para IA.
- Use práticas robustas de autenticação, autorização e gerenciamento de tokens, aproveitando provedores de identidade externos como Microsoft Entra ID sempre que possível.
- Proteja-se contra injeção indireta de prompt e envenenamento de ferramentas validando metadados das ferramentas, monitorando mudanças dinâmicas e usando soluções como Microsoft Prompt Shields.
- Implemente gerenciamento seguro de sessões usando IDs de sessão não determinísticos, vinculando sessões a identidades de usuários e nunca usando sessões para autenticação.
- Previna ataques de delegado confuso exigindo consentimento explícito do usuário para cada cliente registrado dinamicamente e implementando práticas adequadas de segurança OAuth.
- Evite vulnerabilidades de passagem de token garantindo que servidores MCP aceitem apenas tokens explicitamente emitidos para eles e validem adequadamente as claims dos tokens.
- Trate todos os componentes da sua cadeia de suprimentos de IA — incluindo modelos, embeddings e provedores de contexto — com o mesmo rigor das dependências de código.
- Mantenha-se atualizado com as especificações MCP em evolução e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos adicionais

## Recursos externos
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [Especificação MCP](https://spec.modelcontextprotocol.io/)
- [Melhores práticas de segurança MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Especificação de autorização MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Melhores práticas de segurança OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Injeção de prompt no MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Ataques de envenenamento de ferramentas (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls no MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Documentação Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso seguro com menor privilégio (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores práticas para validação e tempo de vida de tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use armazenamento seguro de tokens e criptografe tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como gateway de autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usando Microsoft Entra ID para autenticar com servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Documentos adicionais de segurança

Para orientações de segurança mais detalhadas, consulte estes documentos:

- [Melhores práticas de segurança MCP 2025](./mcp-security-best-practices-2025.md) - Lista abrangente de melhores práticas de segurança para implementações MCP
- [Implementação Azure Content Safety](./azure-content-safety-implementation.md) - Exemplos de implementação para integrar Azure Content Safety com servidores MCP
- [Controles de segurança MCP 2025](./mcp-security-controls-2025.md) - Controles e técnicas de segurança mais recentes para proteger implantações MCP
- [Melhores práticas MCP](./mcp-best-practices.md) - Guia rápido de referência para segurança MCP

### Próximo

Próximo: [Capítulo 3: Começando](../03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.