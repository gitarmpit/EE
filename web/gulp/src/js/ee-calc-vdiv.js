class EE_Vdiv extends EE_Calc {

  Vin = null;
  Vout = null;
  R1 = null;
  R2 = null;

  I_R2 = null;
  I_load = null;
  R_load = null;
  err = null;

  constructor() {
    super("form-vdiv");
    this.Vin = new EE_Calc_V(this.form_name + "-Vin");
    this.Vout = new EE_Calc_V(this.form_name + "-Vout");
    this.R1 = new EE_Calc_R(this.form_name + "-R1");
    this.R2 = new EE_Calc_R(this.form_name + "-R2");
    this.R_load = new EE_Calc_R(this.form_name + "-Rl");
    this.I_R2 = new EE_Calc_I(this.form_name + "-IR2");
    this.I_load = new EE_Calc_I(this.form_name + "-Il");
    this.err = new EE_Calc_Float(this.form_name + "-err");

    this.init();
  }

  clear() {
    this.Vin.clear();
    this.Vout.clear();
    this.R1.clear();
    this.R2.clear();
    this.I_R2.clear();
    this.R_load.clear();
    this.I_load.clear();
    this.err.clear();
  }

  calc_from_err(Vi, Vout, Vout_noload, R3, perr) {

    let err = 1 - perr / 100;
    let div = Vi / Vout_noload;
    let n = div - 1;
    let R2 = R3 * (1 - err) * (n + 1) / (err * n);
    let R1 = R2 * n;
    this.R1.setValue(R1);
    this.R2.setValue(R2);
    let I_R2 = Vout / R2;
    this.I_R2.setValue(I_R2);

  }

  calc(targetId) {
    try {
      let Vin = 0;
      let Vout = 0;
      let R1 = 0;
      let R2 = 0;
      let I_R2 = 0;
      let I_load = 0;
      let R_load = 0;
      let err = 0;
      let cnt = 0;
      let vr_set = false;


      if (!this.Vin.empty()) {
        Vin = this.Vin.getValue();
        ++cnt;
      }

      if (!this.Vout.empty()) {
        Vout = this.Vout.getValue();
        ++cnt;
      }

      if (!this.R1.empty()) {
        R1 = this.R1.getValue();
        ++cnt;
      }

      if (!this.R2.empty()) {
        R2 = this.R2.getValue();
        ++cnt;
      }

      if (!this.I_R2.empty()) {
        I_R2 = this.I_R2.getValue();
        ++cnt;
      }

      if (!this.I_load.empty()) {
        I_load = this.I_load.getValue();
        ++cnt;
      }

      if (!this.R_load.empty()) {
        R_load = this.R_load.getValue();
        ++cnt;
      }

      if (!this.err.empty()) {
        err = this.err.getValue();
        ++cnt;
      }

      if (Vin != 0 && Vout != 0 && Vout >= Vin) {
        throw "invalid input";
      }

      if (cnt == 2 && R1 != 0 && R2 != 0) {
        Vin = 1;
        this.Vin.setValue(Vin);
      }
      else if (cnt == 2 && Vin != 0 && Vout != 0) {
        R2 = 1000;
        this.R2.setValue(R2);
      }

      if (err == 0) {
        if (Vin != 0 && R1 != 0 && R2 != 0) {
          Vout = Vin * R2 / (R1 + R2);
          this.Vout.setValue(Vout);
          vr_set = true;
        }
        else if (Vout != 0 && R1 != 0 && R2 != 0) {
          Vin = Vout * (R1 + R2) / R2;
          this.Vin.setValue(Vin);
          vr_set = true;
        }
        else if (Vin != 0 && R1 != 0 && Vout != 0) {
          R2 = R1 / (Vin / Vout - 1);
          this.R2.setValue(R2);
          vr_set = true;
        }
        else if (Vin != 0 && R2 != 0 && Vout != 0) {
          R1 = R2 * (Vin / Vout - 1);
          this.R1.setValue(R1);
          vr_set = true;
        }
      }

      if (vr_set && cnt == 3) {
        I_R2 = Vout / R2;
        this.I_R2.setValue(I_R2);
      }

      if (cnt == 3 && Vin != 0 && Vout != 0 & I_R2 != 0) {
        let R = Vin / I_R2;
        R2 = Vout / I_R2;
        this.R2.setValue(R2);
        R1 = (Vin - Vout) / I_R2;
        this.R1.setValue(R1);
      }
      else if (vr_set && R_load != 0 && I_load == 0 && err == 0) {
        let Rpar = 1 / (1 / R2 + 1 / R_load);
        let Ir1 = Vin / (R1 + Rpar);
        let Vout_noload = Vout;
        Vout = Vin - Ir1 * R1;
        this.Vout.setValue(Vout);
        err = (1 - Vout / Vout_noload) * 100;
        this.err.setValue(err);
        I_load = Vout / R_load;
        this.I_load.setValue(I_load);
        I_R2 = Vout / R2;
        this.I_R2.setValue(I_R2);
      }
      else if (vr_set && R_load == 0 && I_load != 0 && err == 0) {
        let Vout_noload = Vout;
        R_load = R2 * (Vin - I_load*R1) / (I_load*(R1 + R2));
        if (R_load <= 0) {
          throw "I_load current too high";
        }
        this.R_load.setValue(R_load);
        Vout = I_load * R_load;
        this.Vout.setValue(Vout);
        err = (1 - Vout / Vout_noload) * 100;
        this.err.setValue(err);
        I_R2 = Vout / R2;
        this.I_R2.setValue(I_R2);
      }
      else if (!vr_set && Vin != 0 && Vout != 0 && R_load != 0 && I_load == 0 && err != 0) {

        let Vout_noload = Vout;
        Vout = Vout_noload * (1 - err / 100);
        this.Vout.setValue(Vout);
        I_load = Vout / R_load;
        this.I_load.setValue(I_load);
        this.calc_from_err (Vin, Vout, Vout_noload, R_load, err);
      }
      else if (!vr_set && Vin != 0 && Vout != 0 && R_load == 0 && I_load != 0 && err != 0) {

        let Vout_noload = Vout;
        Vout = Vout_noload * (1 - err / 100);
        this.Vout.setValue(Vout);
        R_load = Vout / I_load;
        this.R_load.setValue(R_load);
        this.calc_from_err (Vin, Vout, Vout_noload, R_load, err);
      }
      else if (!vr_set) {
        throw "invalid input";
      }
    }
    catch (ex) {
      reportError(ex);
    }
  }


}
