import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import CreatePoint from 'src/app/models/CreatePoint';
import Point from 'src/app/models/Point';
import { PointService } from 'src/app/services/point.service';

@Component({
  selector: 'app-point',
  templateUrl: './point.component.html',
  styleUrls: ['./point.component.sass'],
})
export class PointComponent implements OnInit {
  @Input() points: Point[] = [];
  public PointId: number = NaN;
  public xCoordinate: number = NaN;
  public yCoordinate: number = NaN;
  public pointListId: number = NaN;

  constructor(private pointService: PointService) {}

  ngOnInit(): void {
    this.pointService.getAll().subscribe((pointData) => {
      this.points = pointData;
    });
  }

  public updatePoint(pointId: number) {
    this.PointId = pointId;
    let index = this.points.findIndex((x) => x.id == pointId);
    this.xCoordinate = this.points[index].xCoordinate;
    this.yCoordinate = this.points[index].yCoordinate;
    this.pointListId = this.points[index].pointListId;
  }

  public submitUpdatedPoint(): void {
    let updatePoint: CreatePoint = {
      xCoordinate: this.xCoordinate,
      yCoordinate: this.yCoordinate,
      pointListId: this.pointListId,
    };
    this.pointService.update(this.PointId, updatePoint).subscribe();
    this.PointId = NaN;
  }

  public createPoint(createPointEvent: any): void {
    let createPoint: CreatePoint = {
      xCoordinate: createPointEvent.xCoordinate,
      yCoordinate: createPointEvent.yCoordinate,
      pointListId: createPointEvent.pointListId,
    };

    this.pointService.create(createPoint).subscribe((pointId) => {
      let point: Point = {
        id: pointId,
        xCoordinate: createPoint.xCoordinate,
        yCoordinate: createPoint.yCoordinate,
        pointListId: createPoint.pointListId,
      };

      this.points.push(point);
    });
  }
}
