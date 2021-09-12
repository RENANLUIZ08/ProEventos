import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public showImage: boolean = true;
  public eventosFiltrados: any = [];

  private _filtroList: string = "";

  public get filtroList() {
    return this._filtroList;
  }

  public set filtroList(value: string) {
     this._filtroList = value;
     this.eventosFiltrados = this.filtroList ? this.FiltrarEventos(this.filtroList) : this.eventos;
  }

  FiltrarEventos(filter: string): any {
    filter = filter.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filter) !== -1 || evento.local.toLocaleLowerCase().indexOf(filter) !== -1
    )
  }

  widthImage: number = 150;
  marginImage: number = 2;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEventos();
  }

  updateImage(){
    this.showImage = !this.showImage;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }
}
