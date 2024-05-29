import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'prettyData',
  standalone: true
})
export class PrettyDataPipe implements PipeTransform {

  transform(value: any, ...args: unknown[]): unknown {
    let res: string = "";
    Object.keys(value).map(key => {
      res +=  `((${key})) => ${value[key]} `
    })
    return res;
  }

}
