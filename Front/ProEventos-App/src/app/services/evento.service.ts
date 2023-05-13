import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Evento } from "../models/Evento";

// Injeção - pode injetar essa classe em qualquer lugar
@Injectable({
  providedIn: 'root'
})

//Encapsulamento
export class EventoService {
  baseURL = 'https://localhost:44371/api/eventos';
  constructor(private http: HttpClient) { }

  //Obs: retorno do método é um Array de Observable do tipo Evento

  //Retornando uma lista de evento
  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  //Retornando uma lista de evento
  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
  }

  //Retornando um evento
  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
