import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import CreatePoint from 'src/app/models/CreatePoint';
import Point from 'src/app/models/Point';
import { PointService } from 'src/app/services/point.service';
import { StateService } from 'src/app/services/state.service';
import { CreatePointComponent } from '../create-point/create-point.component';
import { UpdatePointComponent } from '../update-point/update-point.component';

@Component({
  selector: 'app-point-catalogue',
  templateUrl: './point-catalogue.component.html',
  styleUrls: ['./point-catalogue.component.sass'],
})
export class PointCatalogueComponent implements OnInit {
  public dataSource: Point[] = [];
  // public pageSlice = this.dataSource.slice(0, 5);
  public newPoint: CreatePoint = {
    xCoordinate: NaN,
    yCoordinate: NaN,
    pointListId: NaN,
  };

  public editPoint: CreatePoint = {
    xCoordinate: NaN,
    yCoordinate: NaN,
    pointListId: NaN,
  };
  public updatePointId: number = NaN;

  displayedColumns: string[] = [
    'xCoordinate',
    'yCoordinate',
    'pointListId',
    'actions',
  ];

  constructor(
    private pointService: PointService,
    private stateService: StateService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.stateService.getAll();

    this.stateService.points$.subscribe((pointData) => {
      this.dataSource = pointData;
    });
  }
  public createPoint(newPoint: any): void {
    // this.pointService.create(newPoint).subscribe((pointId) => {
    //   let point: Point = {
    //     id: pointId,
    //     xCoordinate: newPoint.xCoordinate,
    //     yCoordinate: newPoint.yCoordinate,
    //     pointListId: newPoint.pointListId,
    //   };
    //   this.dataSource.push(point);
    // });
  }

  public removePoint(pointId: number) {
    this.pointService.remove(pointId).subscribe();
    this.dataSource = this.dataSource.filter((s) => s.id != pointId);
  }

  public updatePoint(pointId: number) {
    this.updatePointId = pointId;
    let index = this.dataSource.findIndex((x) => x.id == pointId);
    this.editPoint.xCoordinate = this.dataSource[index].xCoordinate;
    this.editPoint.yCoordinate = this.dataSource[index].yCoordinate;
    this.editPoint.pointListId = this.dataSource[index].pointListId;
  }

  public submitUpdatedPoint(): void {
    let updatePoint: CreatePoint = {
      xCoordinate: this.editPoint.xCoordinate,
      yCoordinate: this.editPoint.yCoordinate,
      pointListId: this.editPoint.pointListId,
    };
    this.pointService.update(this.updatePointId, updatePoint).subscribe();
    this.updatePointId = NaN;
  }

  openCreatePointDialog(): any {
    let dialogRef = this.dialog.open(CreatePointComponent, {
      data: {
        xCoordinate: this.newPoint.xCoordinate,
        yCoordinate: this.newPoint.yCoordinate,
        pointListId: this.newPoint.pointListId,
      },
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

  // public onPageChange(event: PageEvent) {
  //   console.log(event);
  //   const startIndex = event.pageIndex * event.pageSize;
  //   let endIndex = startIndex + event.pageSize;
  //   if ((endIndex = this.dataSource.length)) {
  //     endIndex = this.dataSource.length;
  //   }
  //   this.pageSlice = this.dataSource.slice(startIndex, endIndex);
  // }
}
