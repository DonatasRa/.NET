import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import PointList from '../models/PointList';

@Injectable({
  providedIn: 'root',
})
export class PointListService {
  apiUrl: string = 'https://localhost:7022/pointList';

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<PointList[]> {
    return this.httpClient.get<PointList[]>(this.apiUrl);
  }

  public remove(id: number): Observable<any> {
    return this.httpClient.delete<any>(`${this.apiUrl}/${id}`);
  }

  // public create(createPoint: CreateList): Observable<any> {
  //   return this.httpClient.post<any>(this.apiUrl, createPoint);
  // }

  // public update(updatePoint: CreateList): Observable<any> {
  //   return this.httpClient.put<any>(this.apiUrl, updatePoint);
  // }
}
