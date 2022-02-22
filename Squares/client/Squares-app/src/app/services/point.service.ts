import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import CreatePoint from '../models/CreatePoint';
import Point from '../models/Point';

@Injectable({
  providedIn: 'root',
})
export class PointService {
  apiUrl: string = 'https://localhost:7022/point';

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<Point[]> {
    return this.httpClient.get<Point[]>(this.apiUrl);
  }

  public remove(id: number): Observable<any> {
    return this.httpClient.delete<any>(`${this.apiUrl}/${id}`);
  }

  public create(createPoint: CreatePoint): Observable<any> {
    return this.httpClient.post<any>(this.apiUrl, createPoint);
  }

  public update(pointId: number, updatePoint: CreatePoint): Observable<any> {
    return this.httpClient.put<any>(`${this.apiUrl}/${pointId}`, updatePoint);
  }
}
