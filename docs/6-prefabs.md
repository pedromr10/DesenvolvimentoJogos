### Prefabs
- Nome: gunShot<br>
Descrição: Jean possuirá uma arma e dela sairão balas. Serão disparadas após o pressionamento da tecla ‘P’ do teclado. Terá um som compatível com a arma e conterá colisão, para identificação de inimigos.
Quando são utilizados: após o jogador apertar a tecla selecionada, causará dandos ao oponente.
Scripts: a bala deve dar dano a oponentes caso entrem em colisão, e deve ser destruída após isso.

- Nome: Player<br>
Descrição: O prefab do player, contendo scripts e outras variáveis, animações.
Quando são utilizados: serão utilizados em todas as cenas do game.
Scripts: realiza movimentos do personagem, assim como interação e manutenção da vida do jogador.

- Nome: cactus<br>
Descrição: Prefab de um dos inimigos do deserto, contendo animação, ações.
Quando são utilizados: serão utilizados em duas cenas do deserto.
Scripts: realiza movimentos do inimigo, assim como a função de atirar e manutenção da vida do mesmo.

- Nome: deathArea<br>
Descrição: Prefab para que Jean morra ao cair do mapa e não ficar infinitamente caindo.
Quando são utilizados: serão utilizados em mapas que possuem plataformas flutuantes e que correm o risco de queda de Jean.
Scripts: faz com que Jean morra instantaneamente.

- Nome: espinhoCacto<br>
Descrição: Prefab para manutenção das ações de disparo do cactus.
Quando são utilizados: é utilizado quando o inimigo cactus avistar o player.
Scripts: realiza o disparo de um espinho quando vê o player.

- Nome: portalDeserto<br>
Descrição: prefab para o portal dos mapas de deserto, para prosseguir para a próxima fase.
Quando são utilizados: serão utilizados em todas as cenas do deserto, menos na do boss.
Scripts: faz o player ir para a próxima área.

- Nome: potion<br>
Descrição: Prefab que serve de cura ao personagem principal.
Quando são utilizados: serão utilizados na maioria dos mapas.
Scripts: caso o player tenha menos de 3 vidas, o cura em um ponto de vida. Caso tenha 3 vidas ou mais, nada acontece.

- Nome: skull<br>
Descrição: Prefab de um dos inimigos do deserto, contendo animação, ações.
Quando são utilizados: serão utilizados em duas cenas do deserto.
Scripts: realiza movimentos do inimigo, assim como a função de andar e manutenção da vida do mesmo.
