<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:14:17+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "pt"
}
-->
# Melhores Práticas de Segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações orientadas por IA, mas também introduz desafios únicos de segurança que vão além dos riscos tradicionais de software. Além de preocupações já conhecidas, como codificação segura, princípio do menor privilégio e segurança da cadeia de suprimentos, o MCP e as cargas de trabalho de IA enfrentam novas ameaças como injeção de prompt, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem resultar em exfiltração de dados, violações de privacidade e comportamentos inesperados do sistema se não forem gerenciados adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompt e vulnerabilidades na cadeia de suprimentos — e oferece controles práticos e melhores práticas para mitigá-los. Você também aprenderá como utilizar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para fortalecer sua implementação MCP. Ao entender e aplicar esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompt, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes para mitigar riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Compreender e aproveitar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho MCP e IA.
- Reconhecer a importância de validar metadados das ferramentas, monitorar mudanças dinâmicas e defender-se contra ataques de injeção indireta de prompt.
- Integrar melhores práticas estabelecidas de segurança — como codificação segura, fortalecimento de servidores e arquitetura zero trust — na sua implementação MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança MCP

Qualquer sistema que tenha acesso a recursos importantes enfrenta desafios implícitos de segurança. Esses desafios podem geralmente ser tratados com a aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP é uma especificação recém-definida, seu padrão está mudando rapidamente à medida que o protocolo evolui. Eventualmente, os controles de segurança nele contidos irão amadurecer, permitindo uma melhor integração com arquiteturas corporativas e melhores práticas estabelecidas de segurança.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) afirmam que 98% das violações relatadas poderiam ser evitadas com uma higiene de segurança robusta, e a melhor proteção contra qualquer tipo de violação é garantir uma base sólida de higiene de segurança, práticas de codificação segura e segurança da cadeia de suprimentos — aquelas práticas testadas e comprovadas que já conhecemos continuam sendo as que mais impactam na redução dos riscos de segurança.

Vamos analisar algumas formas de começar a abordar os riscos de segurança ao adotar o MCP.

> **Note:** As informações a seguir estão corretas até **29 de maio de 2025**. O protocolo MCP está em constante evolução, e implementações futuras podem introduzir novos padrões e controles de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [Especificação MCP](https://spec.modelcontextprotocol.io/) e o repositório oficial no [GitHub MCP](https://github.com/modelcontextprotocol) e a [página de melhores práticas de segurança](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declaração do problema  
A especificação original do MCP assumia que os desenvolvedores implementariam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Os servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerenciando diretamente a autenticação do usuário em vez de delegá-la a um serviço externo como o Microsoft Entra ID. A partir de **26 de abril de 2025**, uma atualização da especificação MCP permite que servidores MCP deleguem a autenticação do usuário a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e controles de acesso aplicados incorretamente.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth foi emitido.

#### Token Passthrough
O token passthrough é explicitamente proibido na especificação de autorização, pois introduz vários riscos de segurança, incluindo:

#### Circunvenção de Controle de Segurança
O servidor MCP ou APIs a jusante podem implementar controles importantes como limitação de taxa, validação de requisições ou monitoramento de tráfego, que dependem do público do token ou outras restrições de credenciais. Se os clientes puderem obter e usar tokens diretamente com as APIs a jusante sem que o servidor MCP os valide adequadamente ou assegure que os tokens foram emitidos para o serviço correto, esses controles são ignorados.

#### Problemas de Responsabilização e Auditoria
O servidor MCP não será capaz de identificar ou distinguir entre clientes MCP quando estes fizerem chamadas usando um token de acesso emitido a montante, que pode ser opaco para o servidor MCP.  
Os logs do servidor de recursos a jusante podem mostrar requisições que parecem vir de uma fonte diferente, com uma identidade diferente, e não do servidor MCP que está realmente encaminhando os tokens.  
Ambos os fatores dificultam a investigação de incidentes, controles e auditoria.  
Se o servidor MCP passar tokens sem validar suas declarações (por exemplo, funções, privilégios ou público) ou outros metadados, um agente malicioso em posse de um token roubado pode usar o servidor como proxy para exfiltração de dados.

#### Problemas na Fronteira de Confiança
O servidor de recursos a jusante concede confiança a entidades específicas. Essa confiança pode incluir suposições sobre origem ou padrões de comportamento do cliente. Quebrar essa fronteira de confiança pode levar a problemas inesperados.  
Se o token for aceito por múltiplos serviços sem validação adequada, um invasor que comprometer um serviço pode usar o token para acessar outros serviços conectados.

#### Risco de Compatibilidade Futura
Mesmo que um servidor MCP comece hoje como um “proxy puro”, ele pode precisar adicionar controles de segurança posteriormente. Começar com a separação adequada do público do token facilita a evolução do modelo de segurança.

### Controles mitigadores

**Servidores MCP NÃO DEVEM aceitar tokens que não tenham sido explicitamente emitidos para o servidor MCP**

- **Revisar e Fortalecer a Lógica de Autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes autorizados possam acessar recursos sensíveis. Para orientações práticas, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar Práticas Seguras de Tokens:** Siga as [melhores práticas da Microsoft para validação e tempo de vida de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de tokens.
- **Proteger o Armazenamento de Tokens:** Sempre armazene tokens de forma segura e use criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema  
Servidores MCP podem ter recebido permissões excessivas para o serviço/recurso que estão acessando. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA conectada a um repositório corporativo de dados deveria ter acesso restrito aos dados de vendas, e não a todos os arquivos do repositório. Voltando ao princípio do menor privilégio (um dos princípios de segurança mais antigos), nenhum recurso deve ter permissões além do necessário para executar as tarefas para as quais foi designado. A IA apresenta um desafio maior nesse aspecto, pois para permitir flexibilidade, pode ser difícil definir as permissões exatas necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir a exfiltração ou alteração de dados que o servidor MCP não deveria acessar. Isso também pode representar um problema de privacidade se os dados forem informações pessoais identificáveis (PII).

### Controles mitigadores  
- **Aplicar o Princípio do Menor Privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar suas tarefas. Revise e atualize essas permissões regularmente para garantir que não excedam o necessário. Para orientações detalhadas, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controle de Acesso Baseado em Funções (RBAC):** Atribua papéis ao servidor MCP que sejam estritamente limitados a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorar e Auditar Permissões:** Monitore continuamente o uso das permissões e audite os logs de acesso para detectar e corrigir privilégios excessivos ou não utilizados rapidamente.

# Ataques de injeção indireta de prompt

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt:** Atacantes inserem instruções maliciosas em prompts ou conteúdo externo, fazendo com que o sistema de IA execute ações não intencionais ou vaze dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas:** Atacantes manipulam metadados das ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente burlando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt Cross-Domain:** Instruções maliciosas são inseridas em documentos, páginas web ou emails, que são processados pela IA, levando a vazamento ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls):** Definições de ferramentas podem ser alteradas após aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento do usuário.

Essas vulnerabilidades ressaltam a necessidade de validação robusta, monitoramento e controles de segurança ao integrar servidores MCP e ferramentas no seu ambiente. Para um aprofundamento, veja as referências acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.pt.png)

**Injeção Indireta de Prompt** (também conhecida como injeção cross-domain ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Model Context Protocol (MCP). Nesse ataque, instruções maliciosas são escondidas dentro de conteúdos externos — como documentos, páginas web ou emails. Quando o sistema de IA processa esse conteúdo, pode interpretar essas instruções embutidas como comandos legítimos do usuário, resultando em ações não intencionais como vazamento de dados, geração de conteúdo nocivo ou manipulação das interações do usuário. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Envenenamento de Ferramentas**. Aqui, atacantes inserem instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem desses metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas não autorizadas ou burlar controles de segurança. Essas manipulações são frequentemente invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é aumentado em ambientes de servidores MCP hospedados, onde as definições das ferramentas podem ser atualizadas após a aprovação do usuário — um cenário conhecido como "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta que antes era segura pode ser modificada posteriormente para realizar ações maliciosas, como exfiltrar dados ou alterar o comportamento do sistema, sem o conhecimento do usuário. Para mais informações sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.pt.png)

## Riscos  
Ações não intencionais da IA apresentam vários riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controles mitigadores  
### Usando prompt shields para proteção contra ataques de Injeção Indireta de Prompt
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompt diretos e indiretos. Eles ajudam por meio de:

1.  **Detecção e Filtragem:** Prompt Shields utilizam algoritmos avançados de aprendizado de máquina e processamento de linguagem natural para detectar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou emails.
    
2.  **Spotlighting:** Essa técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma que fique mais relevante para o modelo, o Spotlighting garante que a IA possa identificar melhor e ignorar instruções maliciosas.
    
3.  **Delimitadores e Datamarking:** Incluir delimitadores na mensagem do sistema destaca explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar entradas do usuário de conteúdos externos potencialmente nocivos. O datamarking amplia esse conceito usando marcadores especiais para destacar os limites entre dados confiáveis e não confiáveis.
    
4.  **Monitoramento Contínuo e Atualizações:** A Microsoft monitora e atualiza continuamente os Prompt Shields para lidar com ameaças novas e em evolução. Essa abordagem proativa assegura que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Prompt Shields fazem parte da suíte mais ampla Azure AI Content Safety, que oferece ferramentas adicionais para detectar tentativas de jailbreak, conteúdos nocivos e outros riscos de segurança em aplicações de IA.

Você pode saber mais sobre AI prompt shields na [documentação do Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.pt.png)

### Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, agora é necessário verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um deles pode introduzir vulnerabilidades ou riscos se não for gerenciado adequadamente.

**Práticas-chave de segurança da cadeia de suprimentos para IA e MCP:**
- **Verificar todos os componentes antes da integração:** Isso inclui não apenas bibliotecas open-source, mas também modelos de IA, fontes de dados e APIs externas. Sempre cheque a procedência, licenciamento e vulnerabilidades conhecidas.
- **Manter pipelines de implantação seguros:** Use pipelines CI/CD automatizados com escaneamento de segurança integrado para detectar problemas precocemente. Garanta que apenas artefatos confiáveis sejam implantados em produção.
- **Monitorar e auditar continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques na cadeia de suprimentos.
- **Aplicar princípio do menor privilégio e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do seu servidor MCP.
- **Responder rapidamente a ameaças:** Tenha um processo para corrigir ou substituir componentes comprometidos e para rotacionar segredos ou credenciais caso uma violação seja detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece recursos como varredura de segredos, análise de dependências e CodeQL. Essas ferramentas se integram ao [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades tanto no código quanto nos componentes da cadeia de suprimentos de IA.

A Microsoft também implementa práticas extensivas de segurança da cadeia de suprimentos internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Melhores práticas estabelecidas de segurança que elevarão a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança existente do ambiente da sua organização sobre o qual foi construída. Portanto, ao considerar a segurança do MCP como componente dos seus sistemas gerais de IA, recomenda-se elevar a postura de segurança geral já existente. Os seguintes controles estabelecidos de segurança são especialmente relevantes:

- Melhores práticas de codificação segura na sua aplicação de IA — proteja contra [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras de ponta a ponta entre todos os componentes da aplicação, etc.
- Fortalecimento de servidores — use MFA sempre que possível, mantenha as atualizações em dia, integre o servidor com um provedor de identidade terceirizado para acesso, etc.
- Mantenha
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [A Jornada para Garantir a Segurança da Cadeia de Suprimentos de Software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso Seguro com Privilégios Mínimos (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores Práticas para Validação e Tempo de Vida de Tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Armazenamento Seguro de Tokens e Criptografe os Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como Gateway de Autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Melhores Práticas de Segurança para MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Usando Microsoft Entra ID para Autenticar com Servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Próximo

Próximo: [Capítulo 3: Começando](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.