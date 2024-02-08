import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface CandleStickTreeView {
  timeRange: string;
  open: number;
  close: number;
  high: number;
  low: number;
  sumVolume: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public data: CandleStickTreeView[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.http.get<CandleStickTreeView[]>('/api/candlestick/get-tree-view').subscribe(
      (result) => {
        this.data = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getClasses(item: CandleStickTreeView) {
    return {
      "table-success": item.open < item.close,
      "table-danger": item.open > item.close
    };
  }

  title = 'candlestick.client';
}
