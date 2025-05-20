<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:05:18+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "br"
}
-->
# Security Best Practices

Adotar o Model Context Protocol (MCP) traz novas capacidades poderosas para aplicações baseadas em IA, mas também introduz desafios de segurança únicos que vão além dos riscos tradicionais de software. Além das preocupações já conhecidas, como codificação segura, princípio do menor privilégio e segurança da cadeia de suprimentos, o MCP e as cargas de trabalho de IA enfrentam ameaças novas, como prompt injection, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem resultar em exfiltração de dados, violações de privacidade e comportamentos inesperados do sistema se não forem gerenciados adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP — incluindo autenticação, autorização, permissões excessivas, prompt injection indireto e vulnerabilidades na cadeia de suprimentos — e oferece controles práticos e melhores práticas para mitigá-los. Você também aprenderá como aproveitar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para fortalecer sua implementação do MCP. Compreendendo e aplicando esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Learning Objectives

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos de segurança exclusivos introduzidos pelo Model Context Protocol (MCP), incluindo prompt injection, envenenamento de ferramentas, permissões excessivas e vulnerabilidades na cadeia de suprimentos.
- Descrever e aplicar controles eficazes para mitigar os riscos de segurança do MCP, como autenticação robusta, princípio do menor privilégio, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Entender e utilizar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para proteger cargas de trabalho MCP e IA.
- Reconhecer a importância de validar metadados das ferramentas, monitorar mudanças dinâmicas e defender contra ataques de prompt injection indireto.
- Integrar as melhores práticas de segurança estabelecidas — como codificação segura, hardening de servidores e arquitetura de zero trust — na sua implementação do MCP para reduzir a probabilidade e o impacto de violações de segurança.

# MCP security controls

Qualquer sistema com acesso a recursos importantes enfrenta desafios implícitos de segurança. Esses desafios podem ser geralmente tratados por meio da aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP é uma especificação recém-definida, ela está mudando rapidamente conforme o protocolo evolui. Eventualmente, os controles de segurança internos ao MCP irão amadurecer, permitindo uma melhor integração com arquiteturas e melhores práticas de segurança empresariais já estabelecidas.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) indicam que 98% das violações reportadas seriam evitadas por uma higiene robusta de segurança, e a melhor proteção contra qualquer tipo de violação é garantir que sua higiene básica de segurança, práticas de codificação segura e segurança da cadeia de suprimentos estejam corretas — essas práticas testadas e comprovadas ainda são as que mais impactam na redução do risco de segurança.

Vamos analisar algumas formas de começar a abordar os riscos de segurança ao adotar o MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** As informações a seguir estão corretas até 26 de abril de 2025. O protocolo MCP está em constante evolução, e futuras implementações podem introduzir novos padrões e controles de autenticação. Para atualizações e orientações mais recentes, consulte sempre a [MCP Specification](https://spec.modelcontextprotocol.io/) e o repositório oficial [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
A especificação original do MCP assumia que os desenvolvedores escreveriam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Os servidores MCP atuavam como servidores de autorização OAuth 2.0, gerenciando a autenticação do usuário diretamente, em vez de delegar para um serviço externo como o Microsoft Entra ID. A partir de 26 de abril de 2025, uma atualização na especificação MCP permite que servidores MCP deleguem a autenticação do usuário a um serviço externo.

### Risks  
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e aplicação incorreta de controles de acesso.  
- Roubo de tokens OAuth no servidor MCP local. Se roubado, o token pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth foi emitido.

### Mitigating controls  
- **Review and Harden Authorization Logic:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes autorizados possam acessar recursos sensíveis. Para orientações práticas, consulte [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).  
- **Enforce Secure Token Practices:** Siga as [melhores práticas da Microsoft para validação e tempo de vida de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar o uso indevido de tokens de acesso e reduzir o risco de replay ou roubo.  
- **Protect Token Storage:** Armazene sempre os tokens de forma segura e utilize criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Servidores MCP podem ter recebido permissões excessivas para o serviço ou recurso que estão acessando. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas com IA conectada a um repositório de dados corporativo deve ter acesso restrito apenas aos dados de vendas e não a todos os arquivos do repositório. Retomando o princípio do menor privilégio (um dos mais antigos princípios de segurança), nenhum recurso deve ter permissões além do necessário para executar as tarefas para as quais foi designado. A IA apresenta um desafio maior nesse sentido, pois para garantir flexibilidade, pode ser difícil definir exatamente as permissões necessárias.

### Risks  
- Permissões excessivas podem permitir exfiltração ou alteração de dados que o servidor MCP não deveria acessar. Isso também pode ser um problema de privacidade se os dados forem informações pessoais identificáveis (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para realizar suas tarefas. Revise e atualize essas permissões regularmente para garantir que não excedam o necessário. Para orientações detalhadas, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).  
- **Use Role-Based Access Control (RBAC):** Atribua papéis ao servidor MCP que sejam estritamente limitados a recursos e ações específicas, evitando permissões amplas ou desnecessárias.  
- **Monitor and Audit Permissions:** Monitore continuamente o uso de permissões e audite os logs de acesso para detectar e corrigir rapidamente privilégios excessivos ou não utilizados.

# Indirect prompt injection attacks

### Problem statement

Servidores MCP maliciosos ou comprometidos podem representar riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Prompt Injection Attacks**: Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo o sistema de IA executar ações não desejadas ou vazar dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)  
- **Tool Poisoning**: Atacantes manipulam metadados das ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente burlando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)  
- **Cross-Domain Prompt Injection**: Instruções maliciosas são inseridas em documentos, páginas web ou e-mails, que depois são processados pela IA, levando a vazamentos ou manipulação de dados.  
- **Dynamic Tool Modification (Rug Pulls)**: Definições de ferramentas podem ser alteradas após aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento do usuário.

Essas vulnerabilidades ressaltam a necessidade de validação rigorosa, monitoramento e controles de segurança ao integrar servidores e ferramentas MCP ao seu ambiente. Para um aprofundamento, veja as referências acima.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.br.png)

**Indirect Prompt Injection** (também conhecido como cross-domain prompt injection ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo os que usam o Model Context Protocol (MCP). Nesse ataque, instruções maliciosas são ocultas em conteúdos externos — como documentos, páginas web ou e-mails. Quando o sistema de IA processa esse conteúdo, pode interpretar as instruções embutidas como comandos legítimos do usuário, resultando em ações não desejadas, como vazamento de dados, geração de conteúdo prejudicial ou manipulação das interações do usuário. Para uma explicação detalhada e exemplos reais, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma especialmente perigosa desse ataque é o **Tool Poisoning**. Aqui, os atacantes inserem instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros). Como os grandes modelos de linguagem (LLMs) dependem desses metadados para decidir quais ferramentas usar, descrições comprometidas podem enganar o modelo a executar chamadas de ferramentas não autorizadas ou burlar controles de segurança. Essas manipulações geralmente são invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é maior em ambientes de servidores MCP hospedados, onde as definições das ferramentas podem ser atualizadas após a aprovação do usuário — um cenário às vezes chamado de "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Nesses casos, uma ferramenta antes segura pode ser modificada para realizar ações maliciosas, como exfiltração de dados ou alteração do comportamento do sistema, sem o conhecimento do usuário. Para mais informações sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.br.png)

## Risks  
Ações não intencionais da IA apresentam diversos riscos de segurança, incluindo exfiltração de dados e violações de privacidade.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de prompt injection diretos e indiretos. Eles ajudam por meio de:

1.  **Detecção e Filtragem:** Prompt Shields usam algoritmos avançados de machine learning e processamento de linguagem natural para detectar e filtrar instruções maliciosas embutidas em conteúdos externos, como documentos, páginas web ou e-mails.  
2.  **Spotlighting:** Essa técnica ajuda o sistema de IA a distinguir entre instruções válidas do sistema e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada para torná-lo mais relevante para o modelo, o Spotlighting garante que a IA identifique melhor e ignore instruções maliciosas.  
3.  **Delimitadores e Marcação de Dados:** Incluir delimitadores na mensagem do sistema destaca explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar as entradas do usuário de conteúdos externos potencialmente perigosos. A marcação de dados amplia esse conceito usando marcadores especiais para delimitar dados confiáveis e não confiáveis.  
4.  **Monitoramento Contínuo e Atualizações:** A Microsoft monitora e atualiza continuamente os Prompt Shields para lidar com ameaças novas e em evolução. Essa abordagem proativa garante que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.  
5. **Integração com Azure Content Safety:** Prompt Shields fazem parte do conjunto mais amplo Azure AI Content Safety, que oferece ferramentas adicionais para detectar tentativas de jailbreak, conteúdos nocivos e outros riscos de segurança em aplicações de IA.

Você pode ler mais sobre AI prompt shields na [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.br.png)

### Supply chain security

A segurança da cadeia de suprimentos continua fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, agora você deve verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos base, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um desses pode introduzir vulnerabilidades ou riscos se não for gerenciado corretamente.

**Práticas chave de segurança da cadeia de suprimentos para IA e MCP:**  
- **Verifique todos os componentes antes da integração:** Isso inclui não apenas bibliotecas open source, mas também modelos de IA, fontes de dados e APIs externas. Sempre verifique procedência, licenciamento e vulnerabilidades conhecidas.  
- **Mantenha pipelines de implantação seguros:** Use pipelines CI/CD automatizados com escaneamento de segurança integrado para detectar problemas cedo. Garanta que apenas artefatos confiáveis sejam implantados em produção.  
- **Monitore e audite continuamente:** Implemente monitoramento constante para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques na cadeia de suprimentos.  
- **Aplique o princípio do menor privilégio e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do seu servidor MCP.  
- **Responda rapidamente às ameaças:** Tenha processos para corrigir ou substituir componentes comprometidos e para rotacionar segredos ou credenciais caso uma violação seja detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferece recursos como escaneamento de segredos, escaneamento de dependências e análise CodeQL. Essas ferramentas se integram com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades tanto no código quanto nos componentes da cadeia de suprimentos de IA.

A Microsoft também implementa práticas extensas de segurança da cadeia de suprimentos internamente para todos os seus produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Qualquer implementação do MCP herda a postura de segurança já existente no ambiente da organização onde está construída. Portanto, ao considerar a segurança do MCP como parte dos seus sistemas de IA, recomenda-se fortalecer a postura geral de segurança existente. Os seguintes controles de segurança estabelecidos são especialmente relevantes:

- Práticas de codificação segura em sua aplicação de IA — proteja contra o [OWASP Top 10](https://owasp.org/www-project-top-ten/), o [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras ponta a ponta entre todos os componentes da aplicação, etc.  
- Hardening de servidores — use MFA sempre que possível, mantenha os patches atualizados, integre o servidor a um provedor de identidade terceirizado para controle de acesso, etc.  
- Mantenha dispositivos, infraestrutura e aplicações atualizados com os patches mais recentes.  
- Monitoramento de segurança — implemente logging e monitoramento da aplicação de IA (incluindo cliente/servidores MCP) e envie esses logs para um SIEM central para detectar atividades anômalas.  
- Arquitetura de zero trust — isole componentes via controles de rede e identidade de forma lógica para minimizar movimentação lateral caso a aplicação de IA seja comprometida.

# Key Takeaways

- Fundamentos de segurança continuam críticos: codificação segura, princípio do menor privilégio, verificação da cadeia de suprimentos e monitoramento contínuo são essenciais para cargas de trabalho MCP e IA.  
- MCP introduz novos riscos — como prompt injection, envenenamento de ferramentas e permissões excessivas — que exigem controles tradicionais e específicos para IA.  
- Use práticas robustas de autenticação, autorização e gerenciamento de tokens, aproveitando provedores de identidade externos como Microsoft Entra ID sempre que possível.  
- Proteja contra prompt injection indireto e envenenamento de ferramentas validando metadados das ferramentas, monitorando mudanças dinâmicas e usando soluções como Microsoft Prompt Shields.  
- Trate todos os componentes da sua cadeia de suprimentos de IA — incluindo modelos, embeddings e provedores de contexto — com o mesmo rigor que as dependências de código.  
- Mantenha-se atualizado com as especificações em evolução do MCP e contribua para a comunidade para ajudar a moldar padrões seguros.

# Additional Resources

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
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Next

Próximo: [Capítulo 3: Começando](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.