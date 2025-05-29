<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:14:49+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "br"
}
-->
# Práticas recomendadas de segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações impulsionadas por IA, mas também introduz desafios de segurança únicos que vão além dos riscos tradicionais de software. Além de preocupações estabelecidas como codificação segura, princípio do menor privilégio e segurança da cadeia de suprimentos, MCP e cargas de trabalho de IA enfrentam novas ameaças como injeção de prompt, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos inesperados do sistema se não forem gerenciados adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompt e vulnerabilidades na cadeia de suprimentos — e oferece controles acionáveis e práticas recomendadas para mitigá-los. Você também aprenderá a usar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para fortalecer sua implementação MCP. Compreendendo e aplicando esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos de segurança únicos introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompt, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes para mitigar riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Entender e aproveitar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho MCP e IA.
- Reconhecer a importância de validar metadados das ferramentas, monitorar mudanças dinâmicas e defender-se contra ataques de injeção indireta de prompt.
- Integrar práticas de segurança estabelecidas — como codificação segura, fortalecimento de servidores e arquitetura de zero trust — na sua implementação MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança MCP

Qualquer sistema que tenha acesso a recursos importantes apresenta desafios implícitos de segurança. Esses desafios geralmente podem ser tratados por meio da aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP é uma especificação recém-definida, ela está mudando rapidamente conforme o protocolo evolui. Eventualmente, os controles de segurança nele contidos irão amadurecer, permitindo uma melhor integração com arquiteturas corporativas e práticas recomendadas consolidadas.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) indicam que 98% das violações relatadas poderiam ser evitadas com uma higiene de segurança robusta, e a melhor proteção contra qualquer tipo de violação é garantir uma base sólida de higiene de segurança, práticas de codificação segura e segurança da cadeia de suprimentos — aquelas práticas testadas e comprovadas que ainda são as mais eficazes na redução do risco de segurança.

Vamos ver algumas maneiras de começar a abordar os riscos de segurança ao adotar o MCP.

> **Note:** As informações a seguir estão corretas até **29 de maio de 2025**. O protocolo MCP está em constante evolução, e futuras implementações podem introduzir novos padrões e controles de autenticação. Para atualizações e orientações mais recentes, consulte sempre a [Especificação MCP](https://spec.modelcontextprotocol.io/), o repositório oficial [MCP no GitHub](https://github.com/modelcontextprotocol) e a [página de melhores práticas de segurança](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declaração do problema  
A especificação original do MCP assumia que os desenvolvedores escreveriam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Os servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerenciando a autenticação do usuário diretamente, em vez de delegá-la a um serviço externo, como o Microsoft Entra ID. A partir de **26 de abril de 2025**, uma atualização da especificação MCP permite que servidores MCP deleguem a autenticação do usuário a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e aplicação incorreta de controles de acesso.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth foi emitido.

#### Token Passthrough  
O token passthrough é explicitamente proibido na especificação de autorização, pois introduz diversos riscos de segurança, incluindo:

#### Contorno de controles de segurança  
O servidor MCP ou APIs a jusante podem implementar controles importantes, como limitação de taxa, validação de requisições ou monitoramento de tráfego, que dependem do público do token ou outras restrições de credenciais. Se clientes puderem obter e usar tokens diretamente com as APIs a jusante sem que o servidor MCP os valide corretamente ou garanta que os tokens foram emitidos para o serviço correto, eles contornam esses controles.

#### Problemas de responsabilidade e trilha de auditoria  
O servidor MCP não conseguirá identificar ou distinguir entre clientes MCP quando eles estiverem chamando com um token de acesso emitido a montante, que pode ser opaco para o servidor MCP.  
Os logs do Servidor de Recursos a jusante podem mostrar requisições que parecem vir de uma fonte diferente, com identidade distinta, em vez do servidor MCP que está realmente encaminhando os tokens.  
Ambos os fatores dificultam a investigação de incidentes, controles e auditoria.  
Se o servidor MCP repassar tokens sem validar suas reivindicações (por exemplo, funções, privilégios ou público) ou outros metadados, um agente malicioso com um token roubado pode usar o servidor como proxy para exfiltração de dados.

#### Problemas de fronteira de confiança  
O Servidor de Recursos a jusante concede confiança a entidades específicas. Essa confiança pode incluir suposições sobre origem ou padrões de comportamento do cliente. Quebrar essa fronteira de confiança pode causar problemas inesperados.  
Se o token for aceito por múltiplos serviços sem validação adequada, um invasor que comprometa um serviço pode usar o token para acessar outros serviços conectados.

#### Risco de compatibilidade futura  
Mesmo que um servidor MCP comece hoje como um “proxy puro”, ele pode precisar adicionar controles de segurança depois. Começar com a separação correta do público do token facilita a evolução do modelo de segurança.

### Controles mitigadores

**Servidores MCP NÃO DEVEM aceitar tokens que não tenham sido explicitamente emitidos para o servidor MCP**

- **Revisar e reforçar a lógica de autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes autorizados possam acessar recursos sensíveis. Para orientações práticas, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar práticas seguras de tokens:** Siga as [melhores práticas da Microsoft para validação e tempo de vida de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar uso indevido de tokens de acesso e reduzir o risco de replay ou roubo.
- **Proteger o armazenamento de tokens:** Sempre armazene tokens de forma segura e use criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema  
Servidores MCP podem ter recebido permissões excessivas para o serviço/recurso que estão acessando. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA conectada a um banco de dados empresarial deve ter acesso limitado aos dados de vendas e não poder acessar todos os arquivos da base. Retornando ao princípio do menor privilégio (um dos mais antigos princípios de segurança), nenhum recurso deve ter permissões além do necessário para executar as tarefas para as quais foi designado. A IA apresenta um desafio maior nesse sentido, pois para garantir flexibilidade, pode ser difícil definir exatamente as permissões necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir exfiltração ou alteração de dados que o servidor MCP não deveria acessar. Isso também pode representar um problema de privacidade se os dados forem informações pessoais identificáveis (PII).

### Controles mitigadores  
- **Aplicar o princípio do menor privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para executar suas tarefas. Revise e atualize essas permissões regularmente para garantir que não excedam o necessário. Para orientações detalhadas, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar controle de acesso baseado em funções (RBAC):** Atribua funções ao servidor MCP que sejam estritamente limitadas a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorar e auditar permissões:** Monitore continuamente o uso de permissões e audite os logs de acesso para detectar e corrigir privilégios excessivos ou não utilizados rapidamente.

# Ataques de injeção indireta de prompt

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt:** Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo o sistema de IA executar ações não previstas ou vazar dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas:** Atacantes manipulam metadados das ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção Cross-Domain de Prompt:** Instruções maliciosas são embutidas em documentos, páginas web ou emails, que são então processados pela IA, levando a vazamento ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls):** Definições de ferramentas podem ser alteradas após aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento do usuário.

Essas vulnerabilidades ressaltam a necessidade de validação robusta, monitoramento e controles de segurança ao integrar servidores MCP e ferramentas no seu ambiente. Para um aprofundamento, consulte as referências vinculadas acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.br.png)

**Injeção Indireta de Prompt** (também conhecida como injeção cross-domain ou XPIA) é uma vulnerabilidade crítica em sistemas generativos de IA, incluindo os que usam o Model Context Protocol (MCP). Nesse ataque, instruções maliciosas são ocultadas em conteúdos externos — como documentos, páginas web ou emails. Quando o sistema de IA processa esse conteúdo, pode interpretar as instruções embutidas como comandos legítimos do usuário, resultando em ações não intencionais como vazamento de dados, geração de conteúdo prejudicial ou manipulação das interações do usuário. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Envenenamento de Ferramentas**. Aqui, atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem desses metadados para decidir quais ferramentas invocar, descrições comprometidas podem induzir o modelo a executar chamadas não autorizadas ou contornar controles de segurança. Essas manipulações geralmente são invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é maior em ambientes hospedados de servidores MCP, onde definições de ferramentas podem ser atualizadas após a aprovação do usuário — um cenário às vezes chamado de "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta que antes era segura pode ser modificada para executar ações maliciosas, como exfiltração de dados ou alteração do comportamento do sistema, sem o conhecimento do usuário. Para mais sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.br.png)

## Riscos  
Ações não intencionais da IA apresentam vários riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controles mitigadores  
### Uso de prompt shields para proteger contra ataques de Injeção Indireta de Prompt  
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompt diretos e indiretos. Eles ajudam por meio de:

1.  **Detecção e Filtragem:** Prompt Shields usam algoritmos avançados de aprendizado de máquina e processamento de linguagem natural para detectar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou emails.
    
2.  **Spotlighting:** Essa técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de modo que fique mais relevante para o modelo, o Spotlighting garante que a IA possa identificar melhor e ignorar instruções maliciosas.
    
3.  **Delimitadores e Marcação de Dados:** Incluir delimitadores na mensagem do sistema delimita explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar entradas do usuário de conteúdos externos potencialmente prejudiciais. A marcação de dados (datamarking) amplia esse conceito usando marcadores especiais para destacar os limites de dados confiáveis e não confiáveis.
    
4.  **Monitoramento e Atualizações Contínuas:** A Microsoft monitora e atualiza continuamente os Prompt Shields para lidar com ameaças novas e em evolução. Essa abordagem proativa garante que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Prompt Shields fazem parte da suíte mais ampla Azure AI Content Safety, que oferece ferramentas adicionais para detectar tentativas de jailbreak, conteúdo prejudicial e outros riscos de segurança em aplicações de IA.

Você pode saber mais sobre AI prompt shields na [documentação Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.br.png)

### Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes tradicionais de código, agora é necessário verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um desses pode introduzir vulnerabilidades ou riscos se não for gerenciado adequadamente.

**Práticas-chave de segurança da cadeia de suprimentos para IA e MCP:**  
- **Verificar todos os componentes antes da integração:** Isso inclui não apenas bibliotecas open-source, mas também modelos de IA, fontes de dados e APIs externas. Sempre cheque a procedência, licenciamento e vulnerabilidades conhecidas.  
- **Manter pipelines de implantação seguros:** Use pipelines automatizados de CI/CD com integração de varredura de segurança para detectar problemas cedo. Garanta que apenas artefatos confiáveis sejam implantados em produção.  
- **Monitorar e auditar continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques à cadeia de suprimentos.  
- **Aplicar princípio do menor privilégio e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do servidor MCP.  
- **Responder rapidamente a ameaças:** Tenha processos para corrigir ou substituir componentes comprometidos, e para rotacionar segredos ou credenciais caso uma violação seja detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece recursos como varredura de segredos, análise de dependências e CodeQL. Essas ferramentas se integram com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades tanto no código quanto nos componentes da cadeia de suprimentos de IA.

A Microsoft também aplica práticas extensas de segurança da cadeia de suprimentos internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Práticas de segurança estabelecidas que vão elevar a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança do ambiente da organização onde é construída, portanto, ao considerar a segurança do MCP como parte dos seus sistemas de IA, recomenda-se melhorar a postura de segurança geral existente. Os seguintes controles de segurança estabelecidos são especialmente relevantes:

- Práticas de codificação segura na sua aplicação de IA — proteja contra [OWASP Top 10](https://owasp.org/www-project-top-ten/), o [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras ponta a ponta entre todos os componentes da aplicação, etc.  
- Fortalecimento de servidores — use MFA sempre que possível, mantenha as atualizações em dia, integre o servidor com provedores de identidade de terceiros para controle de acesso, etc.  
- Mantenha dispositivos, infraestrutura e aplicações atualizados com patches  
- Monitoramento de segurança — implemente logging e monitoramento da aplicação de IA (incluindo clientes/servidores
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [A jornada para proteger a cadeia de suprimentos de software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso com privilégios mínimos seguros (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores práticas para validação e tempo de vida de tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use armazenamento seguro de tokens e criptografe os tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como gateway de autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Melhores práticas de segurança MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Usando Microsoft Entra ID para autenticar com servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Próximo

Próximo: [Capítulo 3: Começando](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.