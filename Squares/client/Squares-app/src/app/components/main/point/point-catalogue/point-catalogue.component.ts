import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import CreatePoint from 'src/app/models/CreatePoint';
import Point from 'src/app/models/Point';
import { PointService } from 'src/app/services/point.service';
import { CreatePointComponent } from '../create-point/create-point.component';
import { UpdatePointComponent } from '../update-point/update-point.component';

@Component({
  selector: 'app-point-catalogue',
  templateUrl: './point-catalogue.component.html',
  styleUrls: ['./point-catalogue.component.sass'],
})
export class PointCatalogueComponent implements OnInit {
  @Output() removePointEvent = new EventEmitter<number>();
  @Input() dataSource: Point[] = [];
  public newPoint: CreatePoint = {
    xCoordinate: NaN,
    yCoordinate: NaN,
    pointListId: NaN,
  };
  public updatePointId: number = NaN;
  public updateXCoordinate: number = NaN;
  public updateYCoordinate: number = NaN;
  public updatePointListId: number = NaN;

  displayedColumns: string[] = [
    'xCoordinate',
    'yCoordinate',
    'pointListId',
    'edit',
    'delete',
  ];

  constructor(private pointService: PointService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.pointService.getAll().subscribe((pointData) => {
      this.dataSource = pointData;
    });
  }

  public removePoint(pointId: number) {
    this.removePointEvent.emit(pointId);
  }

  public updatePoint(pointId: number) {
    this.updatePointId = pointId;
    let index = this.dataSource.findIndex((x) => x.id == pointId);
    this.updateXCoordinate = this.dataSource[index].xCoordinate;
    this.updateYCoordinate = this.dataSource[index].yCoordinate;
    this.updatePointListId = this.dataSource[index].pointListId;
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

  openCreatePointDialog() {
    let dialogRef = this.dialog.open(CreatePointComponent, {
      data: {
        xCoordinate: this.newPoint.xCoordinate,
        yCoordinate: this.newPoint.yCoordinate,
        pointListId: this.newPoint.pointListId,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openUpdatePointDialog(id: number) {
    let dialogRef = this.dialog.open(UpdatePointComponent, {
      data: this.dataSource,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.updatePoint(result);
      this.submitUpdatedPoint();
    });
  }
}
