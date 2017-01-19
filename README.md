# Election - Escolha democraticamente o restaurante do dia

Foi utilizado no pacote de testes a biblioteca Moq para criar fakes de dependências. 
Como, por exemplo, no projeto de testes, pasta Services, classe PollServiceTest, 
foi possível criar testes das classes de serviço simulando o comportamento das
Classes do pacote de repositório.

Também foi utilizado o framework Ninject para fazer injeção de dependência, 
como está configurado no projeto WebApi, pasta App_Start, classe NinjectWebCommom.

A votação só é iniciada a partir das 7h da manhã e é encerrada ao meio dia. 
Logo após, o restaurante mais votado é escolhido como vencedor. 
No caso de empate, é escolhido vencedor um dos restaurantes que estiverem empatados.

Para verificar se as votações pertencem a mesma semana, foi criada uma classe no projeto BLL,
pasta Utils, classe CreateWeekOfYearElection que, além de ter sido amplamente testada, cria uma chave que traz o ano e a semana do ano como texto, exemplo: 02/01/2017 e 03/01/2017
teriam o campo 20171

Como futuro aperfeiçoamento, o desenvolvedor pretende melhorar a sistemática de login
uma vez que não é possível visualizar se o/a faminto já está logado, e caso esteja,
qual foi o provedor utilizado. Visto que foi a primeira vez que o desenvolvedor
utilizou o processo de login externo, pode-se dizer que foi uma ótima experiência,
visto que, se tivesse optado por usar o login pronto do Identity, teria sido
uma experiência relativamente mais simples.
