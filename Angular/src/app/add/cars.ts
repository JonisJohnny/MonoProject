export class vehiclemake {

    constructor(
      public id: number,
      public name: string,
      public abrv: string,
    ) {  }
  
  }
  export class vehiclemodel {

    constructor(
      public id: number,
      public makeid: number,
      public name: string,
      public abrv: string,
    ) {  }
  
  }
  export class cars {

    constructor(
      public makeid: number,
      public makename: string,
      public makeabrv: string,
      public modelid: number,
      public modelmakeid: number,
      public modelname: string,
      public modelabrv: string,
    ) {  }
  
  }