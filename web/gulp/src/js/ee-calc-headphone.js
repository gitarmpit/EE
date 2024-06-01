class EE_Headphone extends EE_Calc {

  V = null;
  R = null;
  I = null;
  P = null;
  dbmw = null;
  dbv = null;
  L_db = null;

  constructor() {
    super("form-headphone");
    this.V = new EE_Calc_V(this.form_name + "-V");
    this.R = new EE_Calc_R(this.form_name + "-R");
    this.I = new EE_Calc_I(this.form_name + "-I");
    this.P = new EE_Calc_P(this.form_name + "-P");
    this.dbmw = new EE_Calc_Float(this.form_name + "-sensitivity-dbmw");
    this.dbv = new EE_Calc_Float(this.form_name + "-sensitivity-dbv");
    this.L_db = new EE_Calc_Float(this.form_name + "-loudness");

    this.init();
  }

  clear() {
    this.V.clear();
    this.R.clear();
    this.I.clear();
    this.P.clear();
    this.dbmw.clear();
    this.dbv.clear();
    this.L_db.clear();
  }

  calc(targetId) {
    let dbmw = 0;
    let dbv = 0;
    let R = 0;
    let I = 0;
    let V = 0;
    let P = 0;
    let L_db = 0;
    let n_ohm = 0;
  
    try {
  
      if (!this.dbmw.empty()) {
        dbmw = this.dbmw.getValue();
      }
      if (!this.dbv.empty()) {
        dbv = this.dbv.getValue();
      }
      if (!this.I.empty()) {
        I = this.I.getValue();
        ++n_ohm;
      }
      if (!this.V.empty()) {
        V = this.V.getValue();
        ++n_ohm;
      }
      if (!this.P.empty()) {
        P = this.P.getValue();
        ++n_ohm;
      }
      if (!this.R.empty()) {
        R = this.R.getValue();
        ++n_ohm;
      }
      if (!this.L_db.empty()) {
        L_db = this.L_db.getValue();
      }

  
      if (dbmw != 0 && R != 0) {
        dbv = dbmw - 10 * Math.log10(R / 1000);
        this.dbv.setValue (dbv);
      }
      else if (dbv != 0 && R != 0) {
        dbmw = dbv + 10 * Math.log10(R / 1000);
        this.dbmw.setValue(dbmw);
      }
  
      if (L_db != 0 && P == 0 && dbmw != 0 && R != 0) {
        P = Math.pow(10, (L_db - dbmw) / 10) / 1000;
        this.P.setValue(P);
        ++n_ohm;
      }
  
      if (n_ohm == 2) {
        if (V != 0 && R != 0) {
          I = V / R;
          this.I.setValue(I);
  
          P = I * V;
          this.P.setValue(P);
        }
        else if (V != 0 && I != 0) {
          R = V / I;
          this.R.setValue(R);
  
          P = V * I;
          this.P.setValue(P);
        }
        else if (I != 0 && R != 0) {
          V = I * R;
          this.V.setValue(V);
  
          P = V * I;
          this.P.setValue(P);
        }
        else if (P != 0 && R != 0) {
          V = Math.sqrt(P * R);
          this.V.setValue(V);
  
          I = V / R;
          this.I.setValue(I);
        }
        else if (P != 0 && I != 0) {
          V = P / I;
          this.V.setValue(V);
  
          R = V / I;
          this.R.setValue(R);
        }
        else if (P != 0 && V != 0) {
          R = V * V / P;
          this.R.setValue(R);
  
          I = V / R;
          this.I.setValue(I);
        }
        else {
          throw "invalid parameters"
        }
      }
      else {
        throw "invalid number of parameters"
      }
  
      if (L_db == 0 && P != 0 && dbmw != 0) {
        L_db = dbmw + 10 * Math.log10(P * 1000);
        this.L_db.setValue(L_db);
      }
      else if (P != 0 && dbmw == 0 && dbv == 0 && L_db != 0) {
        dbmw = L_db - 10 * Math.log10(P * 1000);
        this.dbmw.setValue(dbmw);
        dbv = dbmw - 10 * Math.log10(R / 1000);
        this.dbv.setValue(dbv);
      }
  
    }
    catch (err) {
      reportError(err);
    }
  
  }


}
