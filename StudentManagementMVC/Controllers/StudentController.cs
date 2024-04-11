using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.Contracts;
using StudentManagementMVC.Dto;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        // GET: StudentController

        public async Task<ActionResult> Index()
        {
            var students = await _studentRepository.GetAllStudents();
            var studentDetailsDto = _mapper.Map<ICollection<StudentDetailsDto>>(students);
            return View(studentDetailsDto);
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDetail = _mapper.Map<StudentDetailsDto>(student);
            return View(studentDetail);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateStudentDto createStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = _mapper.Map<Student>(createStudent);
            _studentRepository.CreateStudent(newStudent);

            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = _mapper.Map<CreateStudentDto>(student);
            return View(studentDto);
        }

        // POST: StudentController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] CreateStudentDto createStudent)
        {
            if (!ModelState.IsValid)
            {
                return View(createStudent);
            }

            var student = _mapper.Map<Student>(createStudent);
            await _studentRepository.UpdateStudent(student);

            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentRepository.DeleteStudent(student.Id);
            return RedirectToAction(nameof(Index));
        }

        // POST: StudentController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, StudentDetailsDto studentDetails)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentRepository.DeleteStudent(student.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}