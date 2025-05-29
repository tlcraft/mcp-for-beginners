<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-29T20:18:11+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "br"
}
-->
# Práticas recomendadas de segurança

Adotar o Model Context Protocol (MCP) traz capacidades poderosas para aplicações baseadas em IA, mas também introduz desafios únicos de segurança que vão além dos riscos tradicionais de software. Além das preocupações já conhecidas, como codificação segura, privilégio mínimo e segurança da cadeia de suprimentos, MCP e cargas de trabalho de IA enfrentam novas ameaças, como injeção de prompt, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos indesejados do sistema se não forem devidamente gerenciados.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompt e vulnerabilidades na cadeia de suprimentos — e oferece controles práticos e melhores práticas para mitigá-los. Você também aprenderá a utilizar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para fortalecer sua implementação MCP. Ao entender e aplicar esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos únicos de segurança introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompt, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes para mitigar os riscos de segurança do MCP, como autenticação robusta, privilégio mínimo, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Compreender e utilizar soluções Microsoft como Prompt Shields, Azure Content Safety e GitHub Advanced Security para proteger cargas de trabalho MCP e IA.
- Reconhecer a importância de validar metadados de ferramentas, monitorar mudanças dinâmicas e defender-se contra ataques de injeção indireta de prompt.
- Integrar práticas estabelecidas de segurança — como codificação segura, fortalecimento de servidores e arquitetura de zero trust — em sua implementação MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança MCP

Qualquer sistema que tenha acesso a recursos importantes enfrenta desafios implícitos de segurança. Geralmente, esses desafios podem ser tratados por meio da aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP é uma especificação recém-definida, ela está mudando rapidamente conforme o protocolo evolui. Eventualmente, os controles de segurança incorporados amadurecerão, permitindo uma melhor integração com arquiteturas corporativas e práticas consolidadas de segurança.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) indicam que 98% das violações relatadas poderiam ser evitadas com uma higiene robusta de segurança. A melhor proteção contra qualquer tipo de violação é garantir que sua higiene básica de segurança, práticas de codificação segura e segurança da cadeia de suprimentos estejam corretas — essas práticas testadas e comprovadas ainda têm o maior impacto na redução dos riscos de segurança.

Vamos analisar algumas formas de começar a lidar com os riscos de segurança ao adotar o MCP.

# Autenticação do servidor MCP (se sua implementação MCP for anterior a 26 de abril de 2025)

> **Note:** As informações a seguir estão corretas até 26 de abril de 2025. O protocolo MCP está em constante evolução, e futuras implementações podem introduzir novos padrões e controles de autenticação. Para as atualizações e orientações mais recentes, consulte sempre a [MCP Specification](https://spec.modelcontextprotocol.io/) e o repositório oficial [MCP GitHub](https://github.com/modelcontextprotocol).

### Problema  
A especificação original do MCP presumiu que os desenvolvedores criariam seu próprio servidor de autenticação. Isso exigia conhecimento sobre OAuth e restrições de segurança relacionadas. Os servidores MCP atuavam como servidores de autorização OAuth 2.0, gerenciando diretamente a autenticação do usuário, em vez de delegá-la a um serviço externo como o Microsoft Entra ID. A partir de 26 de abril de 2025, uma atualização na especificação MCP permite que os servidores MCP deleguem a autenticação do usuário a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e controles de acesso aplicados incorretamente.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth foi emitido.

### Controles mitigadores
- **Revisar e fortalecer a lógica de autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes autorizados tenham acesso a recursos sensíveis. Para orientações práticas, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar práticas seguras de token:** Siga as [melhores práticas da Microsoft para validação e tempo de vida de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar uso indevido de tokens de acesso e reduzir riscos de replay ou roubo.
- **Proteger o armazenamento de tokens:** Sempre armazene tokens de forma segura e use criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Problema  
Servidores MCP podem ter sido concedidas permissões excessivas para o serviço ou recurso que estão acessando. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas baseada em IA conectada a um repositório de dados corporativo deve ter acesso limitado aos dados de vendas, e não a todos os arquivos do repositório. Retornando ao princípio do menor privilégio (um dos mais antigos princípios de segurança), nenhum recurso deve ter permissões além do necessário para executar as tarefas para as quais foi designado. A IA apresenta um desafio maior nesse sentido, pois para ser flexível, pode ser difícil definir exatamente quais permissões são necessárias.

### Riscos  
- Conceder permissões excessivas pode permitir exfiltração ou alteração de dados que o servidor MCP não deveria acessar. Isso também pode ser um problema de privacidade, caso os dados contenham informações pessoais identificáveis (PII).

### Controles mitigadores
- **Aplicar o princípio do menor privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar suas tarefas. Revise e atualize essas permissões regularmente para garantir que não excedam o necessário. Para orientações detalhadas, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controle de Acesso Baseado em Funções (RBAC):** Atribua ao servidor MCP papéis com escopo restrito a recursos e ações específicas, evitando permissões amplas ou desnecessárias.
- **Monitorar e auditar permissões:** Monitore continuamente o uso das permissões e audite os logs de acesso para detectar e corrigir privilégios excessivos ou não utilizados rapidamente.

# Ataques de injeção indireta de prompt

### Problema

Servidores MCP maliciosos ou comprometidos podem representar riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompt:** Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo com que o sistema de IA execute ações não desejadas ou vaze dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas:** Atacantes manipulam metadados das ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, podendo contornar controles de segurança ou exfiltrar dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt Cross-Domain:** Instruções maliciosas são inseridas em documentos, páginas web ou e-mails, que são então processados pela IA, causando vazamento ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls):** Definições de ferramentas podem ser alteradas após aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento dele.

Essas vulnerabilidades ressaltam a necessidade de validação rigorosa, monitoramento e controles de segurança ao integrar servidores e ferramentas MCP ao seu ambiente. Para um estudo mais aprofundado, veja as referências vinculadas acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.br.png)

**Injeção Indireta de Prompt** (também conhecida como injeção de prompt cross-domain ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Model Context Protocol (MCP). Nesse ataque, instruções maliciosas são escondidas dentro de conteúdos externos — como documentos, páginas web ou e-mails. Quando o sistema de IA processa esse conteúdo, ele pode interpretar as instruções embutidas como comandos legítimos do usuário, resultando em ações não intencionais, como vazamento de dados, geração de conteúdo prejudicial ou manipulação das interações do usuário. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Envenenamento de Ferramentas**. Aqui, atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os modelos de linguagem grande (LLMs) dependem desses metadados para decidir quais ferramentas usar, descrições comprometidas podem enganar o modelo a executar chamadas não autorizadas ou contornar controles de segurança. Essas manipulações geralmente são invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco aumenta em ambientes hospedados de servidores MCP, onde definições de ferramentas podem ser atualizadas após a aprovação do usuário — um cenário às vezes chamado de "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta que antes era segura pode ser modificada para executar ações maliciosas, como exfiltrar dados ou alterar o comportamento do sistema, sem o conhecimento do usuário. Para mais detalhes sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.br.png)

## Riscos  
Ações não intencionais da IA apresentam diversos riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Controles mitigadores  
### Uso de prompt shields para proteção contra ataques de Injeção Indireta de Prompt
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompt diretos e indiretos. Eles atuam por meio de:

1.  **Detecção e filtragem:** Prompt Shields utilizam algoritmos avançados de machine learning e processamento de linguagem natural para detectar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou e-mails.
    
2.  **Spotlighting:** Essa técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de forma que fique mais relevante para o modelo, o spotlighting garante que a IA identifique melhor e ignore instruções maliciosas.
    
3.  **Delimitadores e marcação de dados:** Incluir delimitadores na mensagem do sistema define explicitamente a localização do texto de entrada, ajudando a IA a reconhecer e separar as entradas do usuário de conteúdos externos potencialmente nocivos. A marcação de dados estende esse conceito usando marcadores especiais para destacar os limites entre dados confiáveis e não confiáveis.
    
4.  **Monitoramento contínuo e atualizações:** A Microsoft monitora e atualiza constantemente os Prompt Shields para lidar com novas ameaças e técnicas de ataque em evolução. Essa abordagem proativa mantém as defesas eficazes contra as últimas técnicas de ataque.
    
5. **Integração com Azure Content Safety:** Os Prompt Shields fazem parte do conjunto mais amplo Azure AI Content Safety, que oferece ferramentas adicionais para detectar tentativas de jailbreak, conteúdo prejudicial e outros riscos de segurança em aplicações de IA.

Você pode ler mais sobre AI prompt shields na [documentação Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.br.png)

### Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, agora é necessário verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um deles pode introduzir vulnerabilidades ou riscos se não for gerenciado corretamente.

**Práticas-chave de segurança da cadeia de suprimentos para IA e MCP:**
- **Verificar todos os componentes antes da integração:** Isso inclui não apenas bibliotecas open source, mas também modelos de IA, fontes de dados e APIs externas. Sempre cheque a proveniência, licenciamento e vulnerabilidades conhecidas.
- **Manter pipelines de implantação seguros:** Use pipelines CI/CD automatizados com varreduras de segurança integradas para detectar problemas precocemente. Garanta que apenas artefatos confiáveis sejam implantados em produção.
- **Monitorar e auditar continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques na cadeia de suprimentos.
- **Aplicar privilégio mínimo e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do servidor MCP.
- **Responder rapidamente a ameaças:** Tenha processos para corrigir ou substituir componentes comprometidos, além de rotacionar segredos ou credenciais caso uma violação seja detectada.

O [GitHub Advanced Security](https://github.com/security/advanced-security) oferece recursos como varredura de segredos, análise de dependências e CodeQL. Essas ferramentas se integram ao [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e ao [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades tanto no código quanto nos componentes da cadeia de suprimentos de IA.

A Microsoft também implementa práticas extensas de segurança da cadeia de suprimentos internamente para todos os seus produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Práticas estabelecidas de segurança que elevarão a postura de segurança da sua implementação MCP

Qualquer implementação MCP herda a postura de segurança existente do ambiente da organização onde é construída. Portanto, ao considerar a segurança do MCP como componente dos seus sistemas gerais de IA, recomenda-se elevar a postura de segurança geral já existente. Os seguintes controles estabelecidos são especialmente relevantes:

-   Melhores práticas de codificação segura na sua aplicação de IA — proteção contra [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicação segura ponta a ponta entre todos os componentes da aplicação, etc.
-   Fortalecimento de servidores — uso de MFA sempre que possível, manter atualizações em dia, integrar o servidor com provedores de identidade externos para controle de acesso, etc.
-   Manter dispositivos, infraestrutura e aplicações atualizados com patches.
-   Monitoramento de segurança — implementar logging e monitoramento da aplicação de IA (incluindo clientes/servidores MCP) e enviar esses logs para um SIEM central para detecção de atividades anômalas.
-   Arquitetura zero trust — isolar componentes por meio de controles de rede e identidade de forma lógica para minimizar movimentos laterais caso uma aplicação de IA seja comprometida.

# Principais conclusões

- Fundamentos de segurança continuam críticos: codificação segura, privilégio mínimo, verificação da cadeia de suprimentos e monitoramento contínuo são essenciais para MCP e cargas de trabalho de IA.
- MCP introduz novos riscos — como injeção de prompt, envenenamento de ferramentas e permissões excessivas — que exigem controles tradicionais e específicos para IA.
- Use práticas robustas de autenticação, autorização e gerenciamento de tokens, aproveitando provedores de identidade externos como Microsoft Entra ID sempre que possível.
- Proteja-se contra injeção indireta de prompt e envenenamento de ferramentas validando metadados, monitorando mudanças dinâmicas e utilizando soluções como Microsoft Prompt Shields.
- Trate todos os componentes da sua cadeia de suprimentos de IA — incluindo modelos, embeddings e provedores de contexto — com o mesmo rigor aplicado às dependências de código.
- Mantenha-se atualizado com as especificações MCP em evolução e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos adicionais

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [A Jornada para Garantir a Segurança da Cadeia de Suprimentos de Software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso Seguro com Privilégios Mínimos (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores Práticas para Validação e Tempo de Vida de Token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Armazenamento Seguro de Tokens e Criptografe Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como Gateway de Autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usando Microsoft Entra ID para Autenticar com Servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Próximo

Próximo: [Capítulo 3: Começando](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.