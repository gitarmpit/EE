class EE_Sound extends EE_Calc {

  db = null;
  V_gain = null; 
  P_gain = null;
  L_gain = null; // Loudness gain 

  constructor() {
    super("form-sound");
    const negativeAllowed = true;
    this.db = new EE_Calc_Float(this.form_name + "-db", null, negativeAllowed);
    this.V_gain = new EE_Calc_Float(this.form_name + "-V");
    this.P_gain = new EE_Calc_Float(this.form_name + "-P");
    this.L_gain = new EE_Calc_Float(this.form_name + "-L");

    this.init();
  }

  clear() {
    this.db.clear();
    this.V_gain.clear();
    this.P_gain.clear();
    this.L_gain.clear();
  }

  calc(targetId) {
    let db = 0;
    let V_gain = 0;
    let P_gain = 0;
    let L_gain = 0;
  
    try {
  
      if (!this.db.empty()) {
        db = this.db.getValue();
        if (db > 1000) {
          db = 1000;
        }
        else if (db < -1000) {
          db = -1000;
        }
      }

      if (!this.V_gain.empty()) {
        V_gain = this.V_gain.getValue();
      }
      if (!this.P_gain.empty()) {
        P_gain = this.P_gain.getValue();
      }
      if (!this.L_gain.empty()) {
        L_gain = this.L_gain.getValue();
      }
  
      if (targetId == this.form_name + "-db" && !this.db.empty()) {
        V_gain = P_gain = L_gain = 0;
      }
      else if (targetId == this.form_name + "-V" && V_gain > 0) {
        P_gain = L_gain = 0;
        this.db.clear();
      }
      else if (targetId == this.form_name + "-P" && P_gain > 0) {
        V_gain = L_gain = 0;
        this.db.clear();
      }
      else if (targetId == this.form_name + "-L" && L_gain > 0) {
        V_gain = P_gain = 0;
        this.db.clear();
      }
  
      if (!this.db.empty()) {
        V_gain = Math.pow(10, db / 20);
        P_gain = Math.pow(10, db / 10);
        L_gain = Math.pow(2, db / 10);
      }
      else if (V_gain > 0) {
        db = 20 * Math.log10(V_gain);
        P_gain = Math.pow(10, db / 10);
        L_gain = Math.pow(2, db / 10);
      }
      else if (P_gain > 0) {
        db = 10 * Math.log10(P_gain);
        V_gain = Math.pow(10, db / 20);
        L_gain = Math.pow(2, db / 10);
      }
      else if (L_gain > 0) {
        db = 10 * Math.log2(L_gain);
        V_gain = Math.pow(10, db / 20);
        P_gain = Math.pow(10, db / 10);
      }
      else {
        throw "invalid parameters"
      }

      this.db.setValue(db);
      this.V_gain.setValue(V_gain);
      this.P_gain.setValue(P_gain);
      this.L_gain.setValue(L_gain);

    }
    catch (err) {
      console.log(err);
      reportError(err);
    }
    
  }


}
