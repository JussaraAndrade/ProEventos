import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  // Injeta
  constructor(private http: HttpClient) { }

   /* Método que vai ser chamado antes de inicializar aplicação */
  ngOnInit(): void {
    this.getEventos();
  }

  /*
    Requisita do protocolo http do método get dentro da URL vai fazer o get e vai se inscrever no Observable,
    nesse Observable retorna dois item principais que são response e error.
  */
  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error),
    );
  }

}
