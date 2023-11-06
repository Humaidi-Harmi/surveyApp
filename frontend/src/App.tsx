import React from "react";
import "./App.css";
import httpModule from "./helpers/http.module";
import { ICreateQuestionDto } from "./types/global.typing";
import { ISurveyDto } from "./types/global.typing";
import { ICreateAnswerDto } from "./types/global.typing";
import { IGetQuestionDto } from "./types/global.typing";
import { useState, useEffect } from "react";
import ReactDOM from "react-dom/client";
import ViewSurvey from "./ViewSurvey";
import { Routes, Route, useNavigate } from "react-router-dom";

//const UserContext = createContext(UserContext)
//const [] = useState<>();

const App = () => {
  const [question1, setQuestion1] = useState<ICreateQuestionDto>({
    question: "",
  });
  const [question2, setQuestion2] = useState<ICreateQuestionDto>({
    question: "",
  });
  const [question3, setQuestion3] = useState<ICreateQuestionDto>({
    question: "",
  });

  const [questions, setQuestions] = useState<IGetQuestionDto[]>([]);

  const dateCreate1 = new Date();
  const dateCreate2 = new Date();
  const dateCreate3 = new Date();

  const [survey1, setSurvey1] = useState<ISurveyDto>({ submitTime: "", surveyQuestionsId:"" });
  const [survey2, setSurvey2] = useState<ISurveyDto>({ submitTime: "", surveyQuestionsId:"" });
  const [survey3, setSurvey3] = useState<ISurveyDto>({ submitTime: "", surveyQuestionsId:"" });

  //const [getquestion1, getsetQuestion1] = useState<IGetQuestionDto[]>([]);

  //const [answer1, setAnswer1] = useState<ICreateAnswerDto>({ answer: "",surveysId:"" });
  //const [answer2, setAnswer2] = useState<ICreateAnswerDto>({ answer: "",surveysId:"" });
  //const [answer3, setAnswer3] = useState<ICreateAnswerDto>({ answer: "",surveysId:"" });

  const redirect = useNavigate();

  useEffect(() => {
    httpModule
       .get<IGetQuestionDto[]>("SurveysQuestions/get")
       .then((response) => {
        setQuestions(response.data);
       })
       .catch((error) => {
          alert("Error");
          console.log(error);
       });
  }, []);

  const handleClickSaveBtn = () => {
   // if (question1.question === "" ) {
    //   alert("Fill all fields");
    //   return;
   // }

    httpModule
      .post("/SurveysQuestions/create", question1)
      .catch((error) => console.log(error));

    httpModule
      .post("/Surveys/create", survey1)
      .catch((error) => console.log(error));

     // httpModule
    //  .post("/SurveysAnswers/create", answer1)
     // .catch((error) => console.log(error));

      httpModule
      .post("/SurveysQuestions/create", question2)
      .catch((error) => console.log(error));

    //  httpModule
    ////  .post("/SurveysAnswers/create", answer2)
     // .catch((error) => console.log(error));

      httpModule
      .post("/SurveysQuestions/create", question3)
      .catch((error) => console.log(error));

     // httpModule
     // .post("/SurveysAnswers/create", answer3)
     // .catch((error) => console.log(error));
  };
  const handleClickBackBtn = () => {
    redirect("/");
  };

  return (
    <div className="Survey">
      <div className="SurveyBox">
      
        <div className="SurveyHeader">Survey</div>

        <div className="divider">************************************</div>
        <div className="Questions">Questions Input</div>

        <div className="inputs">
          <input className="question1" placeholder="Question 1" onChange={(e) => setQuestion1({ ...question1, question: e.target.value})}/>
          <input className="question2" placeholder="Question 2" onChange={(e) => setQuestion2({ ...question2, question: e.target.value})}/>
          <input className="question3" placeholder="Question 3" onChange={(e) => setQuestion3({ ...question3, question: e.target.value})}/>
        </div>

        <div className="divider">*************************************</div>
        <div className="Answers">Answers Input</div>

        <div className="inputs">
          <input className="answer1" placeholder="Answer 1" />
          <input className="answer2" placeholder="Answer 2" />
          <input className="answer3" placeholder="Answer 3" />
        </div>

        <div style={{ display: "flex", justifyContent: "center" }}>
          <button className="submitButton" onClick={handleClickSaveBtn}>
            Submit
          </button>
        </div>

        <br></br>

        <div style={{ display: "flex", justifyContent: "center" }}>
          <button className="historySurvey" onClick={handleClickBackBtn}>
            History
          </button>
        </div>
      </div>
    </div>
  );
};
export default App;
