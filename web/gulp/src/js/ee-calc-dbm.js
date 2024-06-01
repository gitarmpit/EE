class EE_dbm extends EE_Calc {

  P = null;
  dbm = null;
  Vrms = null;
  Vpk = null;
  Vpp = null;

  constructor() {
    super("form-dbm");
    this.P = new EE_Calc_P(this.form_name + "-P");
    this.dbm = new EE_Calc_Float(this.form_name + "-dbm");
    this.Vrms = new EE_Calc_V(this.form_name + "-Vrms");
    this.Vpk = new EE_Calc_V(this.form_name + "-Vpk");
    this.Vpp = new EE_Calc_V(this.form_name + "-Vpp");
    this.init();
  }

  clear() {
    this.P.clear();
    this.dbm.clear();
    this.Vrms.clear();
    this.Vpk.clear();
    this.Vpp.clear();
  }

  calc(targetId) {
  
    let nparam = 0;
    let Vrms = 0;
    let Vpk = 0;
    let Vpp = 0;
    let P = 0;
    let dbm = 0;
  
    try {
      if (!this.P.empty()) {
        P = this.P.getValue();
        ++nparam;
      }
      if (!this.dbm.empty()) {
        dbm = this.dbm.getValue();
        ++nparam;
      }
      if (!this.Vrms.empty()) {
        Vrms = this.Vrms.getValue();
        ++nparam;
      }
      if (!this.Vpk.empty()) {
        Vpk = this.Vpk.getValue();
        ++nparam;
      }
      if (!this.Vpp.empty()) {
        Vpp = this.Vpp.getValue();
        ++nparam;
      }

      if (targetId == this.form_name + "-P" && P != 0) {
        dbm = Vrms = Vpk = Vpp = 0;
        nparam = 1;
      }
      else if (targetId == this.form_name +  "-dbm" && dbm != 0) {
        P = Vrms = Vpk = Vpp = 0;
        nparam = 1;
      }
      else if (targetId == this.form_name + "-Vrms" && Vrms != 0) {
        dbm = P = Vpk = Vpp = 0;
        nparam = 1;
      }
      else if (targetId == this.form_name + "-Vpk" && Vpk != 0) {
        dbm = P = Vrms = Vpp = 0;
        nparam = 1;
      }
      else if (targetId == this.form_name + "-Vpp" && Vpp != 0) {
        dbm = P = Vrms = Vpk = 0;
        nparam = 1;
      }
  
      if (nparam == 1) {
        if (P > 0) {
          dbm = 10 * Math.log10(P * 1000);
          this.dbm.setValue(dbm);
          Vrms = Math.sqrt(P * 50);
          this.Vrms.setValue(Vrms);
          Vpk = Vrms * Math.sqrt(2);
          this.Vpk.setValue(Vpk);
          Vpp = 2 * Vpk;
          this.Vpp.setValue(Vpp);
        }
        else if (dbm != 0) {
          P = 0.001 * Math.pow(10, dbm / 10);
          this.P.setValue(P);
          Vrms = Math.sqrt(P * 50);
          this.Vrms.setValue(Vrms);
          Vpk = Vrms * Math.sqrt(2);
          this.Vpk.setValue(Vpk);
          Vpp = 2 * Vpk;
          this.Vpp.setValue(Vpp);
        }
        else if (Vrms > 0) {
          P = Vrms * Vrms / 50;
          this.P.setValue(P);
          dbm = 10 * Math.log10(P * 1000);
          this.dbm.setValue(dbm);
          Vpk = Vrms * Math.sqrt(2);
          this.Vpk.setValue(Vpk);
          Vpp = 2 * Vpk;
          this.Vpp.setValue(Vpp);
        }
        else if (Vpk > 0) {
          Vrms = Vpk / Math.sqrt(2);
          this.Vrms.setValue(Vrms);
          P = Vrms * Vrms / 50;
          this.P.setValue(P);
          dbm = 10 * Math.log10(P * 1000);
          this.dbm.setValue(dbm);
          Vpp = 2 * Vpk;
          this.Vpp.setValue(Vpp);
        }
        else if (Vpp > 0) {
          Vpk = Vpp / 2;
          this.Vpk.setValue(Vpk);
          Vrms = Vpk / Math.sqrt(2);
          this.Vrms.setValue(Vrms);
          P = Vrms * Vrms / 50;
          this.P.setValue(P);
          dbm = 10 * Math.log10(P * 1000);
          this.dbm.setValue(dbm);
        }
        else {
          throw "invalid input";
        }
      }
      else {
        throw "invalid number of parameters";
      }
  
    }
    catch (err) {
      console.log(err);
      reportError(err);
    }
  }

}