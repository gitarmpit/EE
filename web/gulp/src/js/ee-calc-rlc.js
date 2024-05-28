class EE_RLC extends EE_Calc {

  R = null;
  L = null;
  C = null;
  f = null;
  Qs = null;
  Qp = null;

  constructor() {
    super("form-RLC");
    this.R = new EE_Calc_R(this.form_name + "-R");
    this.L = new EE_Calc_L(this.form_name + "-L");
    this.C = new EE_Calc_C(this.form_name + "-C");
    this.f = new EE_Calc_Freq(this.form_name + "-freq");
    this.Qs = new EE_Calc_Float(this.form_name + "-Qs");
    this.Qp = new EE_Calc_Float(this.form_name + "-Qp");

    this.init();
  }

  clear() {
    this.R.clear();
    this.L.clear();
    this.C.clear();
    this.f.clear();
    this.Qs.clear();
    this.Qp.clear();
  }

  calc_Qs(L, R, freq) {
    let Qs = 2 * Math.PI * freq * L / R;
    this.Qs.setValue(Qs);
  }

  calc_Qp(L, R, freq) {
    let Qp = R / (2 * Math.PI * freq * L);
    this.Qp.setValue(Qp);
  }

  calc_Q(L, R, freq, Qs, Qp) {
    if (L > 1e-15 && freq > 1e-15) {
      if (R > 0 && Qs == 0 && Qp == 0) {
        this.calc_Qs(L, R, freq);
        this.calc_Qp(L, R, freq);
      }
      else if (Qs > 0 && R == 0 && Qp == 0) {
        let R = (2 * Math.PI * freq * L) / Qs;
        this.R.setValue(R);
        this.calc_Qp(L, R, freq);
      }
      else if (Qp > 0 && R == 0 && Qs == 0) {
        let R = Qp * (2 * Math.PI * freq * L);
        this.R.setValue(R);
        this.calc_Qs(L, R, freq);
      }
    }
  }

  calc_C(L, freq) {
    let C = 1 / (L * Math.pow(2 * Math.PI * freq, 2));
    this.C.setValue(C);

  }

  calc(targetId) {
    try {
      let nparam = 0;
      let R = 0;
      let L = 0;
      let C = 0;
      let freq = 0;
      let Qs = 0;
      let Qp = 0;

      if (!this.R.empty()) {
        R = this.R.getValue();
        ++nparam;
      }

      if (!this.L.empty()) {
        L = this.L.getValue();
        ++nparam;
      }

      if (!this.C.empty()) {
        C = this.C.getValue();
        ++nparam;
      }

      if (!this.f.empty()) {
        freq = this.f.getValue();
        ++nparam;
      }

      if (!this.Qs.empty()) {
        Qs = this.Qs.getValue();
        ++nparam;
      }

      if (!this.Qp.empty()) {
        Qp = this.Qp.getValue();
        ++nparam;
      }

      if (nparam == 2 || nparam == 3) {
        if (L != 0 && C != 0) {

          if (freq == 0) {
            freq = 1 / (2 * Math.PI * Math.sqrt(L * C));
            if (freq > 0) {
              this.f.setValue (freq);
              this.calc_Q(L, R, freq, Qs, Qp);
            }
          }
        }
        else if (C != 0 && freq != 0) {
          L = 1 / (C * Math.pow(2 * Math.PI * freq, 2));
          this.L.setValue(L);
          this.calc_Q(L, R, freq, Qs, Qp);
        }
        else if (L != 0 && freq != 0) {
          this.calc_C(L, freq);
          this.calc_Q(L, R, freq, Qs, Qp);
        }
        else if (R > 0 && freq > 0 && Qs > 0) {
          L = Qs * R / (2 * Math.PI * freq);
          this.L.setValue(L);
          Qp = 1 / Qs;
          this.Qp.setValue(Qp);
          this.calc_C(L, freq);
        }
        else if (R > 0 && freq > 0 && Qp > 0) {
          L = R / (Qp * 2 * Math.PI * freq);
          this.L.setValue(L);
          Qs = 1 / Qp;
          this.Qs.setValue(Qs);
          this.calc_C(L, freq);
        }
        else if (R > 0 && L > 0 && Qs > 0) {
          freq = Qs * R / (2 * Math.PI * L);
          this.f.setValue(freq);
          Qp = 1 / Qs;
          this.Qp.setValue(Qp);
          this.calc_C(L, freq);
        }
        else if (R > 0 && L > 0 && Qp > 0) {
          freq = R / (2 * Math.PI * L * Qp);
          this.f.setValue(freq);
          Qs = 1 / Qp;
          this.Qs.setValue(Qs);
          this.calc_C(L, freq);
        }
        else {
          throw "invalid input"
        }

      }
      else {
        throw "invalid number of parameters"
      }

    }
    catch (err) {
      console.log(err);
      reportError(err)
    }

  }

}