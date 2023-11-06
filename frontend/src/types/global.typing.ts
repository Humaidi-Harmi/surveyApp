export interface ICreateQuestionDto {
    question: string;
 }

 export interface ISurveyDto {
    submitTime: string;
    surveyQuestionsId: string;
 }

 export interface IGetQuestionDto {
    id: string;
    question: string;
 }

 export interface IGetSurveyDto {
    id: string;
    submitTime: string;
    surveyQuestionsId: string;
    surveyQuestion: string;
 }

 export interface ICreateAnswerDto {
    answer: string;
    surveysId: string;
 }

 export interface IGetAnswerDto {
    id: string;
    surveysId: string;
    question: string;
 }