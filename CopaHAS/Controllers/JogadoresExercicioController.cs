using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models;
using CopaHAS.Models.Enuns;
using Microsoft.AspNetCore.Mvc;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresExercicioController : ControllerBase
    {
        private static List<Jogador> listaJogadores = new List<Jogador>()
        {new Jogador() { Id = 1, Nome = "Hugo Souza", NumeroCamisa = 1, Posicao = "Goleiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 2, Nome = "Yuri Alberto", NumeroCamisa = 9, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 3, Nome = "Lucas Silva", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 4, Nome = "João Pedro", NumeroCamisa = 5, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 5, Nome = "Vinícius Júnior", NumeroCamisa = 11, Posicao = "Ponta Esquerda", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 6, Nome = "Paulo Henrique", NumeroCamisa = 10, Posicao = "Meia", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 7, Nome = "Gabriel Barbosa", NumeroCamisa = 9, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 8, Nome = "Felipe Melo", NumeroCamisa = 8, Posicao = "Volante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 9, Nome = "Eder Militão", NumeroCamisa = 3, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 10, Nome = "Casemiro", NumeroCamisa = 5, Posicao = "Volante", Status = Models.Enuns.StatusJogador.Titular },
    new Jogador() { Id = 11, Nome = "Neymar Jr", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.StatusJogador.Reserva },
    new Jogador() { Id = 12, Nome = "Marquinhos", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.StatusJogador.Titular }
    };
    

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string Nome)
        {
            List<Jogador> lista = listaJogadores.FindAll(j => j.Nome.ToLower().Contains(Nome.ToLower()));
            if (listaJogadores==null)
            {
                return BadRequest("NotFound");
            }
            else
            {
                return Ok(lista);
            }
        }


        [HttpGet("GetTitulares")]
        public IActionResult GetTitulares(string StatusJogador)
        {
           listaJogadores.RemoveAll(j => j.Status == Models.Enuns.StatusJogador.Reserva);
                return Ok (listaJogadores.OrderByDescending(j => j.NumeroCamisa)); 
        }

        
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
           int quantidadeJogadores = listaJogadores.Count;
           int somatorioNumeroCamisa = listaJogadores.Sum(j => j.NumeroCamisa);
           return Ok($"Quantidade de jogadores: {quantidadeJogadores}, Somatório do número da camisa: {somatorioNumeroCamisa}");
        }

       
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Jogador jogador)
        {
            if (jogador.NumeroCamisa > 100)
            {
                return BadRequest("Número da camisa não pode ser maior que 100.");
            }
            else
            {
                listaJogadores.Add(jogador);
                return Ok("Jogador adicionado com sucesso.");
            }
        }
        
        [HttpPost("PostValidacaoNome")]
        public IActionResult PostValidacaoNome(Jogador jogador)
        {
            if (jogador.Posicao.ToLower()!="Goleiro" && jogador.NumeroCamisa == 1)
            {
                return BadRequest("Somente o goleiro pode ter o numero da camisa igual a 1.");
            }
            else
            {
                listaJogadores.Add(jogador);
                return Ok("Jogador adicionado com sucesso.");
            }
        }
        
        
        [HttpGet("GetStatus/{StatusJogador}")]
        public IActionResult GetStatus(string StatusJogador)
        {
           return Ok("{status: " + StatusJogador + "}");
        }
    }
}