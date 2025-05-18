<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:25:11+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "br"
}
-->
# Melhores Práticas de Segurança

Adotar o Model Context Protocol (MCP) traz novas capacidades poderosas para aplicações impulsionadas por IA, mas também introduz desafios únicos de segurança que vão além dos riscos tradicionais de software. Além de preocupações já estabelecidas como codificação segura, menor privilégio e segurança da cadeia de suprimentos, MCP e cargas de trabalho de IA enfrentam novas ameaças, como injeção de prompts, envenenamento de ferramentas e modificação dinâmica de ferramentas. Esses riscos podem levar à exfiltração de dados, violações de privacidade e comportamentos não intencionais do sistema, se não forem geridos adequadamente.

Esta lição explora os riscos de segurança mais relevantes associados ao MCP, incluindo autenticação, autorização, permissões excessivas, injeção indireta de prompts e vulnerabilidades da cadeia de suprimentos, e fornece controles práticos e melhores práticas para mitigá-los. Você também aprenderá a aproveitar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para fortalecer sua implementação do MCP. Compreendendo e aplicando esses controles, você pode reduzir significativamente a probabilidade de uma violação de segurança e garantir que seus sistemas de IA permaneçam robustos e confiáveis.

# Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Identificar e explicar os riscos únicos de segurança introduzidos pelo Model Context Protocol (MCP), incluindo injeção de prompts, envenenamento de ferramentas, permissões excessivas e vulnerabilidades da cadeia de suprimentos.
- Descrever e aplicar controles de mitigação eficazes para riscos de segurança do MCP, como autenticação robusta, menor privilégio, gerenciamento seguro de tokens e verificação da cadeia de suprimentos.
- Compreender e utilizar soluções da Microsoft, como Prompt Shields, Azure Content Safety e GitHub Advanced Security, para proteger cargas de trabalho de MCP e IA.
- Reconhecer a importância de validar metadados de ferramentas, monitorar mudanças dinâmicas e defender-se contra ataques de injeção indireta de prompts.
- Integrar melhores práticas de segurança estabelecidas — como codificação segura, fortalecimento de servidores e arquitetura de confiança zero — em sua implementação do MCP para reduzir a probabilidade e o impacto de violações de segurança.

# Controles de segurança do MCP

Qualquer sistema que tenha acesso a recursos importantes tem desafios de segurança implícitos. Os desafios de segurança geralmente podem ser abordados por meio da aplicação correta de controles e conceitos fundamentais de segurança. Como o MCP foi definido recentemente, a especificação está mudando rapidamente à medida que o protocolo evolui. Eventualmente, os controles de segurança dentro dele amadurecerão, permitindo uma melhor integração com arquiteturas de segurança empresariais e melhores práticas estabelecidas.

Pesquisas publicadas no [Microsoft Digital Defense Report](https://aka.ms/mddr) afirmam que 98% das violações relatadas seriam evitadas por uma higiene robusta de segurança, e a melhor proteção contra qualquer tipo de violação é acertar sua higiene de segurança básica, melhores práticas de codificação segura e segurança da cadeia de suprimentos — aquelas práticas testadas e comprovadas que já conhecemos ainda fazem o maior impacto na redução do risco de segurança.

Vamos examinar algumas das maneiras pelas quais você pode começar a abordar riscos de segurança ao adotar o MCP.

# Autenticação de servidor MCP (se sua implementação do MCP foi antes de 26 de abril de 2025)

### Declaração do problema
A especificação original do MCP assumia que os desenvolvedores escreveriam seu próprio servidor de autenticação. Isso exigia conhecimento de OAuth e restrições de segurança relacionadas. Servidores MCP atuavam como Servidores de Autorização OAuth 2.0, gerenciando a autenticação de usuário necessária diretamente, em vez de delegá-la a um serviço externo, como o Microsoft Entra ID. A partir de 26 de abril de 2025, uma atualização na especificação do MCP permite que servidores MCP deleguem a autenticação de usuários a um serviço externo.

### Riscos
- Lógica de autorização mal configurada no servidor MCP pode levar à exposição de dados sensíveis e controles de acesso aplicados incorretamente.
- Roubo de token OAuth no servidor MCP local. Se roubado, o token pode ser usado para se passar pelo servidor MCP e acessar recursos e dados do serviço para o qual o token OAuth é destinado.

### Controles de mitigação
- **Revisar e Fortalecer a Lógica de Autorização:** Audite cuidadosamente a implementação de autorização do seu servidor MCP para garantir que apenas usuários e clientes pretendidos possam acessar recursos sensíveis. Para orientações práticas, veja [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Impor Práticas Seguras de Token:** Siga [as melhores práticas da Microsoft para validação e duração de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para prevenir o uso indevido de tokens de acesso e reduzir o risco de repetição ou roubo de tokens.
- **Proteger o Armazenamento de Tokens:** Sempre armazene tokens de forma segura e use criptografia para protegê-los em repouso e em trânsito. Para dicas de implementação, veja [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissões excessivas para servidores MCP

### Declaração do problema
Servidores MCP podem ter recebido permissões excessivas para o serviço/recurso ao qual estão acessando. Por exemplo, um servidor MCP que faz parte de uma aplicação de vendas de IA conectando-se a um repositório de dados empresarial deve ter acesso limitado aos dados de vendas e não ser permitido acessar todos os arquivos no repositório. Referenciando o princípio do menor privilégio (um dos princípios de segurança mais antigos), nenhum recurso deve ter permissões além do que é necessário para executar as tarefas para as quais foi destinado. A IA apresenta um desafio aumentado nesse espaço porque, para habilitá-la a ser flexível, pode ser desafiador definir as permissões exatas necessárias.

### Riscos
- Conceder permissões excessivas pode permitir a exfiltração ou alteração de dados que o servidor MCP não deveria ser capaz de acessar. Isso também pode ser um problema de privacidade se os dados forem informações pessoalmente identificáveis (PII).

### Controles de mitigação
- **Aplicar o Princípio do Menor Privilégio:** Conceda ao servidor MCP apenas as permissões mínimas necessárias para executar suas tarefas necessárias. Revise e atualize regularmente essas permissões para garantir que não excedam o necessário. Para orientações detalhadas, veja [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Controle de Acesso Baseado em Funções (RBAC):** Atribua funções ao servidor MCP que sejam estritamente limitadas a recursos e ações específicos, evitando permissões amplas ou desnecessárias.
- **Monitorar e Auditar Permissões:** Monitore continuamente o uso de permissões e audite logs de acesso para detectar e remediar privilégios excessivos ou não utilizados prontamente.

# Ataques de injeção indireta de prompts

### Declaração do problema

Servidores MCP maliciosos ou comprometidos podem introduzir riscos significativos ao expor dados de clientes ou permitir ações não intencionais. Esses riscos são especialmente relevantes em cargas de trabalho baseadas em IA e MCP, onde:

- **Ataques de Injeção de Prompts**: Atacantes inserem instruções maliciosas em prompts ou conteúdos externos, fazendo com que o sistema de IA realize ações não intencionais ou vaze dados sensíveis. Saiba mais: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamento de Ferramentas**: Atacantes manipulam metadados de ferramentas (como descrições ou parâmetros) para influenciar o comportamento da IA, potencialmente contornando controles de segurança ou exfiltrando dados. Detalhes: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeção de Prompt entre Domínios**: Instruções maliciosas são incorporadas em documentos, páginas da web ou e-mails, que são então processados pela IA, levando ao vazamento ou manipulação de dados.
- **Modificação Dinâmica de Ferramentas (Rug Pulls)**: Definições de ferramentas podem ser alteradas após a aprovação do usuário, introduzindo novos comportamentos maliciosos sem o conhecimento do usuário.

Essas vulnerabilidades destacam a necessidade de validação robusta, monitoramento e controles de segurança ao integrar servidores e ferramentas MCP em seu ambiente. Para um mergulho mais profundo, veja as referências vinculadas acima.

**Injeção Indireta de Prompt** (também conhecida como injeção de prompt entre domínios ou XPIA) é uma vulnerabilidade crítica em sistemas de IA generativa, incluindo aqueles que usam o Model Context Protocol (MCP). Neste ataque, instruções maliciosas estão ocultas dentro de conteúdos externos — como documentos, páginas da web ou e-mails. Quando o sistema de IA processa esse conteúdo, pode interpretar as instruções incorporadas como comandos legítimos do usuário, resultando em ações não intencionais como vazamento de dados, geração de conteúdo prejudicial ou manipulação de interações do usuário. Para uma explicação detalhada e exemplos do mundo real, veja [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Uma forma particularmente perigosa desse ataque é o **Envenenamento de Ferramentas**. Aqui, os atacantes injetam instruções maliciosas nos metadados das ferramentas MCP (como descrições ou parâmetros de ferramentas). Como os grandes modelos de linguagem (LLMs) dependem desses metadados para decidir quais ferramentas invocar, descrições comprometidas podem enganar o modelo para executar chamadas de ferramentas não autorizadas ou contornar controles de segurança. Essas manipulações são frequentemente invisíveis para os usuários finais, mas podem ser interpretadas e executadas pelo sistema de IA. Esse risco é aumentado em ambientes de servidores MCP hospedados, onde definições de ferramentas podem ser atualizadas após a aprovação do usuário — um cenário às vezes referido como "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Em tais casos, uma ferramenta que era anteriormente segura pode ser posteriormente modificada para realizar ações maliciosas, como exfiltração de dados ou alteração do comportamento do sistema, sem o conhecimento do usuário. Para mais sobre esse vetor de ataque, veja [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Riscos
Ações não intencionais da IA apresentam uma variedade de riscos de segurança que incluem exfiltração de dados e violações de privacidade.

### Controles de mitigação
### Usando escudos de prompt para se proteger contra ataques de Injeção Indireta de Prompts
-----------------------------------------------------------------------------

**AI Prompt Shields** são uma solução desenvolvida pela Microsoft para defender contra ataques de injeção de prompts, tanto diretos quanto indiretos. Eles ajudam por meio de:

1.  **Detecção e Filtragem**: Prompt Shields usam algoritmos avançados de aprendizado de máquina e processamento de linguagem natural para detectar e filtrar instruções maliciosas incorporadas em conteúdos externos, como documentos, páginas da web ou e-mails.
    
2.  **Spotlighting**: Esta técnica ajuda o sistema de IA a distinguir entre instruções do sistema válidas e entradas externas potencialmente não confiáveis. Ao transformar o texto de entrada de uma maneira que o torne mais relevante para o modelo, o Spotlighting garante que a IA possa identificar e ignorar melhor instruções maliciosas.
    
3.  **Delimitadores e Marcação de Dados**: Incluir delimitadores na mensagem do sistema delineia explicitamente a localização do texto de entrada, ajudando o sistema de IA a reconhecer e separar entradas do usuário de conteúdos externos potencialmente prejudiciais. A marcação de dados estende esse conceito usando marcadores especiais para destacar os limites de dados confiáveis e não confiáveis.
    
4.  **Monitoramento e Atualizações Contínuas**: A Microsoft monitora e atualiza continuamente os Prompt Shields para abordar ameaças novas e em evolução. Essa abordagem proativa garante que as defesas permaneçam eficazes contra as técnicas de ataque mais recentes.
    
5. **Integração com Azure Content Safety:** Prompt Shields fazem parte do conjunto mais amplo de Azure AI Content Safety, que fornece ferramentas adicionais para detectar tentativas de jailbreak, conteúdos prejudiciais e outros riscos de segurança em aplicações de IA.

Você pode ler mais sobre escudos de prompt de IA na [documentação do Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Segurança da cadeia de suprimentos

A segurança da cadeia de suprimentos continua sendo fundamental na era da IA, mas o escopo do que constitui sua cadeia de suprimentos se expandiu. Além dos pacotes de código tradicionais, agora você deve verificar e monitorar rigorosamente todos os componentes relacionados à IA, incluindo modelos de fundação, serviços de embeddings, provedores de contexto e APIs de terceiros. Cada um deles pode introduzir vulnerabilidades ou riscos se não for gerido adequadamente.

**Práticas chave de segurança da cadeia de suprimentos para IA e MCP:**
- **Verifique todos os componentes antes da integração:** Isso inclui não apenas bibliotecas de código aberto, mas também modelos de IA, fontes de dados e APIs externas. Sempre verifique a proveniência, licenciamento e vulnerabilidades conhecidas.
- **Mantenha pipelines de implantação seguros:** Use pipelines CI/CD automatizados com escaneamento de segurança integrado para detectar problemas cedo. Certifique-se de que apenas artefatos confiáveis sejam implantados em produção.
- **Monitore e audite continuamente:** Implemente monitoramento contínuo para todas as dependências, incluindo modelos e serviços de dados, para detectar novas vulnerabilidades ou ataques na cadeia de suprimentos.
- **Aplique menor privilégio e controles de acesso:** Restrinja o acesso a modelos, dados e serviços apenas ao necessário para o funcionamento do seu servidor MCP.
- **Responda rapidamente a ameaças:** Tenha um processo em vigor para corrigir ou substituir componentes comprometidos e para rotacionar segredos ou credenciais se uma violação for detectada.

[GitHub Advanced Security](https://github.com/security/advanced-security) fornece recursos como escaneamento de segredos, escaneamento de dependências e análise CodeQL. Essas ferramentas se integram com [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ajudar equipes a identificar e mitigar vulnerabilidades em componentes de código e da cadeia de suprimentos de IA.

A Microsoft também implementa práticas extensivas de segurança da cadeia de suprimentos internamente para todos os produtos. Saiba mais em [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Melhores práticas de segurança estabelecidas que melhorarão a postura de segurança da sua implementação do MCP

Qualquer implementação do MCP herda a postura de segurança existente do ambiente da sua organização sobre o qual é construída, portanto, ao considerar a segurança do MCP como um componente dos seus sistemas de IA em geral, recomenda-se que você considere melhorar sua postura de segurança existente em geral. Os seguintes controles de segurança estabelecidos são especialmente pertinentes:

-   Melhores práticas de codificação segura em sua aplicação de IA — proteja-se contra [os 10 principais da OWASP](https://owasp.org/www-project-top-ten/), os [10 principais da OWASP para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de cofres seguros para segredos e tokens, implementação de comunicações seguras de ponta a ponta entre todos os componentes da aplicação, etc.
-   Fortalecimento de servidores — use MFA sempre que possível, mantenha as atualizações em dia, integre o servidor com um provedor de identidade de terceiros para acesso, etc.
-   Mantenha dispositivos, infraestrutura e aplicações atualizados com patches
-   Monitoramento de segurança — implementação de registro e monitoramento de uma aplicação de IA (incluindo o cliente/servidores MCP) e envio desses logs para um SIEM central para detecção de atividades anômalas
-   Arquitetura de confiança zero — isolando componentes por meio de controles de rede e identidade de forma lógica para minimizar o movimento lateral se uma aplicação de IA for comprometida.

# Conclusões Principais

- Fundamentos de segurança permanecem críticos: Codificação segura, menor privilégio, verificação da cadeia de suprimentos e monitoramento contínuo são essenciais para cargas de trabalho de MCP e IA.
- MCP introduz novos riscos — como injeção de prompts, envenenamento de ferramentas e permissões excessivas — que exigem controles tanto tradicionais quanto específicos para IA.
- Use práticas robustas de autenticação, autorização e gerenciamento de tokens, aproveitando provedores de identidade externos como Microsoft Entra ID sempre que possível.
- Proteja-se contra injeção indireta de prompts e envenenamento de ferramentas validando metadados de ferramentas, monitorando mudanças dinâmicas e usando soluções como Microsoft Prompt Shields.
- Trate todos os componentes em sua cadeia de suprimentos de IA — incluindo modelos, embeddings e provedores de contexto — com o mesmo rigor que dependências de código.
- Mantenha-se atualizado com as especificações evolutivas do MCP e contribua para a comunidade para ajudar a moldar padrões seguros.

# Recursos Adicionais

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [A Jornada para Proteger a Cadeia de Suprimentos de Software na Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acesso Seguro com Menor Privilégio (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Melhores Práticas para Validação de Token e Tempo de Vida](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Armazenamento Seguro de Tokens e Criptografe Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Gerenciamento de API do Azure como Gateway de Autenticação para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usando Microsoft Entra ID para Autenticar com Servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Próximo 

Próximo: [Capítulo 3: Primeiros Passos](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, é recomendada a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.