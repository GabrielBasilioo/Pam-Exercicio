using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresController : ControllerBase
    {
        private static List<Jogador> listaJogadores = new List<Jogador>()
        {
           new Jogador() { Id = 1, Nome = "Hugo Souza", NumeroCamisa = 1, Posicao = "Goleiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 2, Nome = "Yuri Alberto", NumeroCamisa = 9, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 3, Nome = "Lucas Silva", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 4, Nome = "João Pedro", NumeroCamisa = 5, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 5, Nome = "Vinícius Júnior", NumeroCamisa = 11, Posicao = "Ponta Esquerda", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 6, Nome = "Paulo Henrique", NumeroCamisa = 10, Posicao = "Meia", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 7, Nome = "Gabriel Barbosa", NumeroCamisa = 9, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 8, Nome = "Felipe Melo", NumeroCamisa = 8, Posicao = "Volante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 9, Nome = "Eder Militão", NumeroCamisa = 3, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 10, Nome = "Casemiro", NumeroCamisa = 5, Posicao = "Volante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 11, Nome = "Neymar Jr", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 12, Nome = "Marquinhos", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular }
};
        public IActionResult ObterJogadores()
        {
            List<Jogador> lista = listaJogadores;
            return Ok(lista);
        } 

        [HttpPost]
        public IActionResult InserirJogador(Jogador j)
        {
            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }


    }
}