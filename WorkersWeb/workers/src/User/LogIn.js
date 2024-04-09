import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { logIn } from '../services/userService';

const schema = yup.object({
  UserName: yup.string().required('Required field'),
  Password: yup.string().required('Required field').min(3, 'סיסמא חייבת להכיל לפחות 3 תווים'),
}).required();

export default function App() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmit = (data) => {
    dispatch(logIn(data, navigate));
  };

  return (
    <>
      <div id="container" style={{ display: "flex", justifyContent: 'center', paddingTop: "50px" }}>
        <div id="form" className="ui placeholder segment">
          <form onSubmit={handleSubmit(onSubmit)}>
            <div className="ui one column very relaxed stackable grid">
              <div className="column">
                <div className="ui form">
                  <div className="field">
                    <label>שם משתמש:</label>
                    <div className="ui right icon input">
                      <i className="user icon"></i>
                      <input placeholder="הכנס שם משתמש" {...register("UserName")} />
                    </div>
                    {errors.UserName && <p className="ui pointing red basic label">{errors.UserName?.message}</p>}
                  </div>
                  <div className="field">
                    <label>סיסמא:</label>
                    <div className="ui right icon input">
                      <i className="lock icon"></i>
                      <input type="password" placeholder="הכנס סיסמא" {...register("Password")} />
                    </div>
                    {errors.Password && <p className="ui pointing red basic label">{errors.Password?.message}</p>}
                  </div>
                  <button className="ui submit button" style={{ backgroundColor: "rgb(19 23 122) ", color: 'white' }} type="submit">Connection</button>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </>
  );
}
