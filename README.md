# Ascent Lab - Blog

Bem-vindo ao **Ascent Lab**, o ponto de encontro dos engenheiros lunáticos!  
Este projeto open source tem como objetivo reunir profissionais que ousam transformar a prática da engenharia civil, promovendo conhecimento e inovação por meio de um blog dinâmico e colaborativo.

## 🎯Objetivo

O Ascent Lab é um espaço dedicado aos profissionais da engenharia civil que querem ir além do convencional.  
Aqui, você encontrará conteúdos sobre:
- **BIM e Tecnologias Inovadoras**: Discussões e insights sobre a construção digital.
- **Tendências de Mercado**: Análises e notícias que moldam o futuro do setor.
- **Desenvolvimento de Softwares**: Tutoriais, cursos gratuitos e ferramentas práticas.
- **Colaboração e Conhecimento**: Um ambiente colaborativo para aprender e compartilhar experiências.

## 🧑‍🚀Requisitos

### Funcionais
- **Postagens**: Artigos, posts e notícias com:
  - Comentários
  - Avaliações
  - Ferramenta de pesquisa
- **Controle de Usuários**:
  - Autenticação e autorização via ASP.NET Identity
  - Gestão de usuários e perfis
- **Gerenciamento de Arquivos**:
  - Upload e download de planilhas, PDFs, arquivos Autodesk e arquivos Open BIM
- **Editor de Conteúdo**: Interface intuitiva para criação e edição de posts
- **Newsletter**: Sistema para envio de comunicados e novidades
- **Agendamento de Publicações**: Planejamento e automação das postagens
- **Painel Administrativo (CMS)**: Área de controle e gerenciamento do conteúdo
- **Integração com Redes Sociais**: Compartilhamento e interação com as principais plataformas

### Não Funcionais
- **SEO Otimizado**: Estrutura pensada para maximizar a visibilidade online
- **Custo Baixo**: Solução econômica e escalável
- **Facilidade de Manutenção**: Código organizado e de fácil compreensão
- **Curva de Aprendizado Reduzida**: Ferramentas intuitivas para desenvolvedores e colaboradores

## 🧑‍💻Stack de Tecnologias

| **Área**                   | **Tecnologia / Abordagem**                                           |
| -------------------------- | ---------------------------------------------------------------------|
| **Front-end**              | Razor Pages (ASP.NET Core)                                             |
| **Back-end**               | ASP.NET Core MVC                                                     |
| **Autenticação**           | ASP.NET Identity                                                     |
| **Acesso a Dados**         | ASP.NET Entity Framework ou Dapper                                   |
| **API Rest**               | ASP.NET Core (com documentação via Swagger)                          |
| **Banco de Dados**         | PostgreSQL                                                           |
| **Infra & Deploy**         | Render (PaaS)                                                        |
| **Search**                 | Full-Text Search em PostgreSQL                                       |
| **Painel Administrativo**  | Implementação customizada em Razor Pages (mesmo projeto)               |
| **CI/CD**                  | GitHub Actions                                                       |
| **Logs & Monitoramento**   | Serilog + Sentry                                                     |
| **Cache & CDN**            | Cloudflare (plano gratuito)                                            |
| **Armazenamento de Arquivos** | Amazon S3                                                      |
| **Testes**                 | xUnit (unitários e de integração) + Playwright (E2E)                   |
| **Internacionalização (i18n)** | Recursos nativos de Localization no ASP.NET Core                |
| **Analytics & SEO**        | Google Analytics e práticas avançadas de SEO on-page                   |
| **Backup & Recovery**      | Backup gerenciado no Render + `pg_dump` externo                        |

## 🪛Instalação e Configuração

1. **Clone o Repositório**
   ```bash
   git clone https://github.com/seu-usuario/ascent-lab-blog.git
