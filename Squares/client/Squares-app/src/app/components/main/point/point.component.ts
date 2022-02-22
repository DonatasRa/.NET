import { Component, EventEmitter, Input, OnInit } from '@angular/core';
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
  public updatePointId: number = NaN;
  public updateXCoordinate: number = NaN;
  public updateYCoordinate: number = NaN;
  public updatePointListId: number = NaN;

  constructor(private pointService: PointService) {}

  ngOnInit(): void {
    this.pointService.getAll().subscribe((pointData) => {
      this.points = pointData;
    });
  }

  public updatePoint(pointId: number) {
    this.updatePointId = pointId;
    let index = this.points.findIndex((x) => x.id == pointId);
    this.updateXCoordinate = this.points[index].xCoordinate;
    this.updateYCoordinate = this.points[index].yCoordinate;
    this.updatePointListId = this.points[index].pointListId;
  }

  public submitUpdatedPoint(): void {
    let updatePoint: CreatePoint = {
      xCoordinate: this.updateXCoordinate,
      yCoordinate: this.updateYCoordinate,
      pointListId: this.updatePointListId,
    };
    this.pointService.update(this.updatePointId, updatePoint).subscribe();
    // this.dataSource.forEach((x) => {
    //   if (x.id == this.idToEdit) {
    //     x.name = this.updateName;
    //   }
    // });
    this.updatePointId = NaN;
  }

  public removePoint(removePointEvent: any): void {
    let id = removePointEvent;
    this.pointService.remove(id).subscribe();
    this.points = this.points.filter((s) => s.id != id);
  }
}
