import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import CreatePoint from '../models/CreatePoint';
import Point from '../models/Point';
import { PointService } from './point.service';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  // We are using this to transmit updated Points
  public points$ = new BehaviorSubject<Point[]>([]);
  private points: Point[] = [];

  constructor(private pointService: PointService) {}

  public getAll() {
    this.pointService.getAll().subscribe((points) => {
      this.points = points;
      this.points$.next(this.points);
    });
  }

  public create(point: CreatePoint): any {
    this.pointService.create(point).subscribe(
      (point) => {
        this.points.push(point);
        this.points$.next(this.points);
      },
      (err: HttpErrorResponse) => {
        console.log(err.error);
      }
    );
  }

  public update(pointId: number, updatePoint: CreatePoint): any {
    this.pointService.update(pointId, updatePoint).subscribe(
      (point) => {
        this.points.push(point);
        this.points$.next(this.points);
      },
      (err: HttpErrorResponse) => {
        console.log(err.error);
      }
    );
  }
}
